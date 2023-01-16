using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Research : State
{
    public override void Action()
    {
        Cursor.lockState = CursorLockMode.None; //Ŀ�� �� ����
        Cursor.visible = true;
        if (Input.GetMouseButtonDown(0))
            ResearchMode();

        if (Input.GetButtonUp("Research"))
            InputManager.Instance.ChangeState(StateName.Idle);


        if (Input.GetButtonDown("Inventory"))//�κ��丮
            InputManager.Instance.ChangeState(StateName.Inventory);

        if (Input.GetButtonDown("ItemSetRelease"))//������ ��������
        {
            SoundManager.Instance.UIAudioPlay(UISound.Next);
            ItemManager.Instance.SetItem(0);
        }

        if (Input.GetButtonDown("UsedKnife"))//Į ���
        {
            if (ItemManager.Instance.FindItem("Knife"))
                BloodManager.Instance.UsedKnife();
        }
    }

    private void ResearchMode()//������
    {
        //Ŀ�� ����ĳ��Ʈ
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 5))
        {
            //����ĳ��Ʈ�� ������ ���ǿ� ������ �����ؾ��ϴ� ��
            Debug.DrawRay(ray.origin, ray.direction * 10, new Color(255, 1, 1, 1), 1);
            Debug.Log(hit.collider.gameObject.name);

            if (GameManager.Instance.isRunMode)
            {
                if (hit.collider.gameObject.name != "Swit")
                    return;

            }

            //ȣ������϶��� ���� �� ���Ұ��ϰ� ����
            InterActionAdapter inter = hit.collider.gameObject.GetComponent<InterActionAdapter>();
            inter?.Interaction();
            

        }
    }
}
