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
        //호러모드로 변경
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
        //트리거 범위 안에 들어왔을 때 공격 (플레이어 카메라 강제 이동)
        //플레이어 화면 block 설정
        cam.Priority = 20;


        BloodManager.Instance.Hurt(10);

        //일정시간 지나 카메라 되돌리기
    }

    public void DestroyObject()
    {
         Destroy(gameObject);
        //사라질 때 파티클 생성
    }
}
