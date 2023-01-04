using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Paintball : State
{
    [SerializeField]
    private GameObject paintBall;

    public override void Action()
    {
        Cursor.lockState = CursorLockMode.None; //Ŀ�� �� ����

        if (Input.GetButtonUp("PaintBall"))//����Ʈ��
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
            //����ĳ��Ʈ�� ������ ���ǿ� ������ �����ؾ��ϴ� ��
            Debug.DrawRay(ray.origin, ray.direction * 20, new Color(255, 1, 1, 1), 1);
            Debug.Log(hit.collider.gameObject.name);


            //����Ʈ�� ��� ����
            if(hit.collider !=null)
            {
                Instantiate(paintBall);
            }

            //����Ʈ�� ���;׼� ����
            PaintAdapter paint = hit.collider.gameObject.GetComponent<PaintAdapter>();
            paint?.PaintInteraction();

            //InterActionAdapter inter = hit.collider.gameObject.GetComponent<InterActionAdapter>();
            //inter?.Interaction();
        }
    }
}
