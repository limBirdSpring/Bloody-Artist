using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class State_Block : State
{
    public override void Action()
    {
        Cursor.lockState = CursorLockMode.None; //Ŀ�� �� ����
        Cursor.visible = false;
    }
}
