using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_BlockResearch : State
{

    // Update is called once per frame
    public override void Action()
    {
        Cursor.lockState = CursorLockMode.None; //Ŀ�� �� ����
        Cursor.visible = true;
        if (Input.GetMouseButtonDown(0))
            ResearchMode();
    }

    private void ResearchMode()//������
    {
        //Ŀ�� ����ĳ��Ʈ
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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
