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

            Cursor.lockState = CursorLockMode.None; //Ŀ�� �� ����
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


    //��ư������
    public void PunchEvent()
    {
        //ȭ�� ��鸲 ȿ�� -> ���ӸŴ��� ����

        SoundManager.Instance.UIAudioPlay(UISound.Punch);
        punch++;
    }
}
