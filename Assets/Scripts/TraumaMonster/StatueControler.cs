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
            Debug.Log("Ʈ���� �浹");
            if (curAttackCoroutine == null)
                Attack();

            //�÷��̾� ��� Ʈ���žȿ� ���� �� �����ð��� �ΰ� ���� ��� �ݺ�
        }
    }

    private void Attack()
    {
        //Ʈ���� ���� �ȿ� ������ �� ���� (�÷��̾� ī�޶� ���� �̵�)
        //�÷��̾� ȭ�� block ����


        curAttackCoroutine = StartCoroutine(AttackCoroutine());


        //�����ð� ���� ī�޶� �ǵ�����
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
        //����� �� ��ƼŬ ����
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
