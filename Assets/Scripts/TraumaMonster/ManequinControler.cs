using Cinemachine;
using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class ManequinControler : MonoBehaviour
{
    [SerializeField]
    private Collider trigger;

    [SerializeField]
    private CinemachineVirtualCamera cam;

    private void OnEnable()
    {
        //ȣ������ ����
    }

    private void Update()
    {
       // Move();
        
    }

    private void Move()
    {
        Attack();
    }

    private void Attack()
    {
        //Ʈ���� ���� �ȿ� ������ �� ���� (�÷��̾� ī�޶� ���� �̵�)
        //�÷��̾� ȭ�� block ����
        cam.Priority = 20;


        BloodManager.Instance.Hurt(10);

        //�����ð� ���� ī�޶� �ǵ�����
    }

    public void DestroyObject()
    {
         Destroy(gameObject);
        //����� �� ��ƼŬ ����
    }
}
