using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Paintball : State
{
    [SerializeField]
    private GameObject paintBall;

    public override void Action()
    {
        Cursor.lockState = CursorLockMode.None; //커서 락 해제

        if (Input.GetButtonUp("PaintBall"))//페인트볼
            InputManager.Instance.ChangeState(StateName.Idle);

        if (Input.GetMouseButtonDown(0))
            ThrowPaintBall();
    }

    private void ThrowPaintBall()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 20))
        {
            //레이캐스트가 조사할 물건에 닿으면 진행해야하는 것
            Debug.DrawRay(ray.origin, ray.direction * 20, new Color(255, 1, 1, 1), 1);
            Debug.Log(hit.collider.gameObject.name);


            //페인트볼 쏘기 진행
            if(hit.collider !=null)
            {
                Instantiate(paintBall);
            }

            //페인트볼 인터액션 진행
            PaintAdapter paint = hit.collider.gameObject.GetComponent<PaintAdapter>();
            paint?.PaintInteraction();

            //InterActionAdapter inter = hit.collider.gameObject.GetComponent<InterActionAdapter>();
            //inter?.Interaction();
        }
    }
}
