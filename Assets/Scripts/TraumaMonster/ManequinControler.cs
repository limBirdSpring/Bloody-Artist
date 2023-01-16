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

    public bool isMove = false;

    private NavMeshAgent agent;

    private Coroutine curCoroutine = null;

    private Coroutine curAttackCoroutine = null;

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
        {
            curCoroutine = StartCoroutine(MoveCoroutine());

            if (!GameManager.Instance.isRunMode)
            {
                Destroy(gameObject);//전등 끄면 사라짐
            }
        }
    }

    private IEnumerator MoveCoroutine()
    {
        yield return new WaitForSeconds(1f);
        agent.destination = player.position;
        curCoroutine = null;
        anim.SetBool("Move", true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (isMove && other.gameObject.name == "Player")
        {
            Debug.Log("트리거 충돌");
            if (curAttackCoroutine == null)
                Attack();

            //플레이어 계속 트리거안에 있을 시 일정시간을 두고 공격 계속 반복
        }
    }

    private void Attack()
    {
        //트리거 범위 안에 들어왔을 때 공격 (플레이어 카메라 강제 이동)
        //플레이어 화면 block 설정
 

        curAttackCoroutine = StartCoroutine(AttackCoroutine());
       

        //일정시간 지나 카메라 되돌리기
    }

    private IEnumerator AttackCoroutine()
    {
        anim.SetBool("Move", false);
        isMove = false;
        anim.SetBool("Attack", true);
        isMove = false;
        cam.Priority = 20;

        yield return new WaitForSeconds(1f);
        BloodManager.Instance.Hurt(10);
        anim.SetBool("Attack", false);

        yield return new WaitForSeconds(2f);
        cam.Priority = 1;
        anim.SetBool("Move", false);
        isMove = true;
        curAttackCoroutine = null;

    }

    public void DestroyObject()
    {
        ExpManager.Instance.AddExp("Yellow");
         Destroy(gameObject);
        //사라질 때 파티클 생성
    }
}
