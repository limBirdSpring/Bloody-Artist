using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class State_Paintball : State
{

    [SerializeField]
    private Canvas paintCanvas;

    [SerializeField]
    private Canvas uiCanvas;

    [SerializeField]
    private Image target;


    public override void Action()
    {
        SetTarget();

        Cursor.lockState = CursorLockMode.None; //커서 락 해제

        paintCanvas.gameObject.SetActive(true);
        uiCanvas.gameObject.SetActive(false);

        if (Input.GetButtonUp("PaintBall"))//페인트볼
        {
            paintCanvas.gameObject.SetActive(false);
            uiCanvas.gameObject.SetActive(true);
            InputManager.Instance.ChangeState(StateName.Idle);
        }

        if (Input.GetMouseButtonDown(0))
            ThrowPaintBall();
    }

    private void SetTarget()
    {
        float mouseX = Mathf.Clamp(Input.mousePosition.x,0, Screen.width) + 40;
        float mouseY = Mathf.Clamp(Input.mousePosition.y, 0, Screen.height) - 100;

        target.transform.position = new Vector2(mouseX, mouseY);
    }


    private void ThrowPaintBall()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Mathf.Clamp(Input.mousePosition.x, 0, Screen.width), Mathf.Clamp(Input.mousePosition.y, 0, Screen.height)));
        if (Physics.Raycast(ray, out hit, 20))
        {
            //레이캐스트가 조사할 물건에 닿으면 진행해야하는 것
            Debug.DrawRay(ray.origin, ray.direction * 20, new Color(255, 1, 1, 1), 1);
            Debug.Log(hit.collider.gameObject.name);


            //페인트볼 쏘기 진행
            if(hit.collider !=null)
            {
                string name = "";

                switch(Random.Range(1,6))
                {
                    case 1:
                        name = "PinkPaint";
                        break;
                    case 2:
                        name = "BluePaint";
                        break;
                    case 3:
                        name = "GreenPaint";
                        break;
                    case 4:
                        name = "PupplePaint";
                        break;
                    case 5:
                        name = "YellowPaint";
                        break;
                }

                PoolManager.Instance.InitObjectFromPool(name, hit.point, Quaternion.LookRotation(hit.normal));

            }

            //페인트볼 인터액션 진행
            PaintAdapter paint = hit.collider.gameObject.GetComponent<PaintAdapter>();
            paint?.PaintInteraction();

        }
    }
}
