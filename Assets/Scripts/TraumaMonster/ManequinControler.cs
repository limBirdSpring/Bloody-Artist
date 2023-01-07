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
            Debug.Log("Ʈ���� �浹");
            anim.SetBool("Move", false);
            isMove = false;
            Attack();

            //�÷��̾� ��� Ʈ���žȿ� ���� �� �����ð��� �ΰ� ���� ��� �ݺ�
        }
    }

    private void Attack()
    {
        //Ʈ���� ���� �ȿ� ������ �� ���� (�÷��̾� ī�޶� ���� �̵�)
        //�÷��̾� ȭ�� block ����

        anim.SetBool("Attack", true);
        isMove = false;
        cam.Priority = 20;

        StartCoroutine(AttackCoroutine());
       

        //�����ð� ���� ī�޶� �ǵ�����
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
        //����� �� ��ƼŬ ����
    }
}
