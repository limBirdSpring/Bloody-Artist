using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_BlockResearch : State
{

    // Update is called once per frame
    public override void Action()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Mathf.Clamp(Input.mousePosition.x, 0, Screen.width), Mathf.Clamp(Input.mousePosition.y, 0, Screen.height)));
        if (Physics.Raycast(ray, out hit, 5) && GameManager.Instance.IsCurCursor("Research") && !GameManager.Instance.isRunMode)
        {
            if (hit.collider.gameObject.GetComponent<Researchable>() != null)
            {
                //���簡�� Ŀ���� ����
                GameManager.Instance.CursorChange("research");
            }
            else if (hit.collider.gameObject.GetComponent<GetableItem>() != null)
            {
                //�ݱⰡ�� Ŀ���� ����
                GameManager.Instance.CursorChange("item");
            }
            else if (hit.collider.gameObject.GetComponent<GemGivable>() != null)
            {
                //��ȭ���� Ŀ���� ����
                GameManager.Instance.CursorChange("Talk");
            }
            else
            {
                //�׳� Ŀ���� ����
                GameManager.Instance.CursorChange("normal");
            }
        }

        Cursor.lockState = CursorLockMode.None; //Ŀ�� �� ����
        Cursor.visible = true;
        if (Input.GetMouseButtonDown(0))
            ResearchMode();
    }

    private void ResearchMode()//������
    {
        //Ŀ�� ����ĳ��Ʈ
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Mathf.Clamp(Input.mousePosition.x, 0, Screen.width), Mathf.Clamp(Input.mousePosition.y, 0, Screen.height)));
        if (Physics.Raycast(ray, out hit, 10))
        {
            //����ĳ��Ʈ�� ������ ���ǿ� ������ �����ؾ��ϴ� ��
            Debug.DrawRay(ray.origin, ray.direction * 10, new Color(255, 1, 1, 1), 1);
            Debug.Log(hit.collider.gameObject.name);

            InterActionAdapter inter = hit.collider.gameObject.GetComponent<InterActionAdapter>();
            inter?.Interaction();
        }
    }
}
