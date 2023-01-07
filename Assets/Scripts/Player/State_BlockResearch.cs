using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_BlockResearch : State
{

    // Update is called once per frame
    public override void Action()
    {
        Cursor.lockState = CursorLockMode.None; //커서 락 해제
        Cursor.visible = true;
        if (Input.GetMouseButtonDown(0))
            ResearchMode();
    }

    private void ResearchMode()//조사모드
    {
        //커서 레이캐스트
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 10))
        {
            //레이캐스트가 조사할 물건에 닿으면 진행해야하는 것
            Debug.DrawRay(ray.origin, ray.direction * 10, new Color(255, 1, 1, 1), 1);
            Debug.Log(hit.collider.gameObject.name);

            InterActionAdapter inter = hit.collider.gameObject.GetComponent<InterActionAdapter>();
            inter?.Interaction();
        }
    }
}
