using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Research : State
{

    public override void Action()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Mathf.Clamp(Input.mousePosition.x, 0, Screen.width), Mathf.Clamp(Input.mousePosition.y, 0, Screen.height)));
        if (Physics.Raycast(ray, out hit, 5) && GameManager.Instance.IsCurCursor("Research") && !GameManager.Instance.isRunMode)
        {
            if (hit.collider.gameObject.GetComponent<Researchable>() !=null)
            {
                //조사가능 커서로 변경
                GameManager.Instance.CursorChange("research");
            }
            else if (hit.collider.gameObject.GetComponent<GetableItem>() != null)
            {
                //줍기가능 커서로 변경
                GameManager.Instance.CursorChange("item");
            }
            else if (hit.collider.gameObject.GetComponent<GemGivable>() != null)
            {
                //대화가능 커서로 변경
                GameManager.Instance.CursorChange("Talk");
            }
            else
            {
                //그냥 커서로 변경
                GameManager.Instance.CursorChange("normal");
            }
        }

        Cursor.lockState = CursorLockMode.None; //커서 락 해제
        Cursor.visible = true;

        if (Input.GetMouseButtonDown(0))
            ResearchMode();

        if (Input.GetButtonUp("Research"))
        {
            InputManager.Instance.ChangeState(StateName.Idle);
        }

        if (Input.GetButtonDown("Inventory"))//인벤토리
            InputManager.Instance.ChangeState(StateName.Inventory);

        if (Input.GetButtonDown("ItemSetRelease"))//아이템 장착해제
        {
            SoundManager.Instance.UIAudioPlay(UISound.Next);
            ItemManager.Instance.SetItem(0);
        }

        if (Input.GetButtonDown("UsedKnife"))//칼 사용
        {
            if (ItemManager.Instance.FindItem("Knife"))
                BloodManager.Instance.UsedKnife();
        }
    }

    private void ResearchMode()//조사모드
    {
        //커서 레이캐스트
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Mathf.Clamp(Input.mousePosition.x, 0, Screen.width), Mathf.Clamp(Input.mousePosition.y, 0, Screen.height)));
        if (Physics.Raycast(ray, out hit, 5))
        {
            //레이캐스트가 조사할 물건에 닿으면 진행해야하는 것
            Debug.DrawRay(ray.origin, ray.direction * 10, new Color(255, 1, 1, 1), 1);
            Debug.Log(hit.collider.gameObject.name);

            if (GameManager.Instance.isRunMode)
            {
                if (hit.collider.gameObject.name != "Swit")
                    return;
            }

            //호러모드일때는 전등 외 사용불가하게 막음
            InterActionAdapter inter = hit.collider.gameObject.GetComponent<InterActionAdapter>();
            inter?.Interaction();
            

        }
    }
}
