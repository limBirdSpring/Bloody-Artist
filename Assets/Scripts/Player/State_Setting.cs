using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Setting : State
{
    [SerializeField]
    private Canvas SettingCanvas;

    public override void Action()
    {
        SettingCanvas.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None; //Ŀ�� �� ����
        Cursor.visible = true;

        if (Input.GetButtonDown("Cancel"))//����
        {
            SoundManager.Instance.UIAudioPlay(UISound.ScreenOn);
            SettingCanvas.gameObject.SetActive(false);
            InputManager.Instance.ChangeState(StateName.Idle);
        }
    }
}
