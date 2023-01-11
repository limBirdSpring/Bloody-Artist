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
                Destroy(gameObject);//���� ���� �����
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
        if (isMove && other.gameObject.name == "Player")
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
        curAttackCoroutine = null;

    }

    public void DestroyObject()
    {
        Destroy(gameObject);
        //����� �� ��ƼŬ ����
    }
}
