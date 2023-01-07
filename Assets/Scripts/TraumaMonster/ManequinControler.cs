using Cinemachine;
using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Scripting.APIUpdating;

public class ManequinControler : MonoBehaviour
{

    [SerializeField]
    private CinemachineVirtualCamera cam;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private bool isMove = false;

    private NavMeshAgent agent;

    private Coroutine curCoroutine = null;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
         Move();
        
    }

    private void Move()
    {
        
        if (isMove && curCoroutine == null)
            curCoroutine = StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        yield return new WaitForSeconds(2f);
        agent.destination = player.position;
        curCoroutine = null;
        anim.SetBool("Move", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isMove && other.gameObject.name == "Player")
        {
            Debug.Log("트리거 충돌");
            anim.SetBool("Move", false);
            isMove = false;
            Attack();

            //플레이어 계속 트리거안에 있을 시 일정시간을 두고 공격 계속 반복
        }
    }

    private void Attack()
    {
        //트리거 범위 안에 들어왔을 때 공격 (플레이어 카메라 강제 이동)
        //플레이어 화면 block 설정

        anim.SetBool("Attack", true);
        isMove = false;
        cam.Priority = 20;

        StartCoroutine(AttackCoroutine());
       

        //일정시간 지나 카메라 되돌리기
    }

    private IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(1f);
        BloodManager.Instance.Hurt(10);
        cam.Priority = 1;
        anim.SetBool("Attack", false);

        yield return new WaitForSeconds(2f);
        isMove = true;

    }

    public void DestroyObject()
    {
         Destroy(gameObject);
        //사라질 때 파티클 생성
    }
}
