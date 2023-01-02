using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Talking : State
{
    public override void Action()
    {
        Cursor.lockState = CursorLockMode.None; //Ŀ�� �� ����
        Cursor.visible = true;


        if (Input.GetMouseButtonDown(0))
        {
            TalkManager.Instance.Talk();
        }
    }
}
