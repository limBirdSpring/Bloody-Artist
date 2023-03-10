using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StatueControler : MonoBehaviour
{

    [SerializeField]
    private CinemachineVirtualCamera cam;

    [SerializeField]
    private Transform player;

    public bool isMove = false;

    private NavMeshAgent agent;

    private Coroutine curCoroutine = null;

    private Coroutine curAttackCoroutine = null;

    [SerializeField]
    private bool traumaMonster = false;


    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
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
                DestroyObject();
            }
        }
    }

    private IEnumerator MoveCoroutine()
    {
        yield return new WaitForSeconds(1f);
        agent.destination = player.position;
        curCoroutine = null;

    }

    private void OnTriggerStay(Collider other)
    { 
        if (isMove && other.gameObject.name == "Player" && traumaMonster)
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
        isMove = false;
        cam.Priority = 20;

        yield return new WaitForSeconds(1f);
        BloodManager.Instance.Hurt(10);


        yield return new WaitForSeconds(2f);
        cam.Priority = 1;
        isMove = true;
        yield return new WaitForSeconds(2f);
        curAttackCoroutine = null;

    }

    public void DestroyObject()
    {
        ExpManager.Instance.AddExp("Blue");
        Destroy(gameObject);
        //사라질 때 파티클 생성
    }

    public void Fast()
    {
        if (!GameManager.Instance.isRunMode)
            return;

        if (SoundManager.Instance.curBGM != BGMSound.RunFast)
            SoundManager.Instance.SetBgm(BGMSound.RunFast, 0);
        agent.speed = 8;
    }
}
