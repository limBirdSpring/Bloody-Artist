using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class State_MiniGame : State
{
    [SerializeField]
    private Button punchButton;

    private int punch;

    private float coolTime;

    private bool action;

    public override void Action()
    {
        if (action == false)
        {
            punchButton.transform.position = Input.mousePosition;
            punchButton.gameObject.SetActive(true);

            Cursor.lockState = CursorLockMode.None; //커서 락 해제
            Cursor.visible = true;

            action = true;
        }
        coolTime += Time.deltaTime;

        if (coolTime > 3)
        {

            if (punch > 10)
            {
                punchButton.gameObject.SetActive(false);
                action = false;
                InputManager.Instance.ChangeState(StateName.Researching);
                
            }
            punch = 0;
            coolTime = 0;
        }
    }


    //버튼누를시
    public void PunchEvent()
    {
        //화면 흔들림 효과 -> 게임매니저 구현

        SoundManager.Instance.UIAudioPlay(UISound.Punch);
        punch++;
    }
}
