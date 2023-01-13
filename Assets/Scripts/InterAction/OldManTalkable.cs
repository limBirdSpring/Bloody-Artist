using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OldManTalkable : MonoBehaviour
{
    [SerializeField]
    private Dialogue dialogue;

    [SerializeField]
    private Dialogue dialogue2;

    [SerializeField]
    private CinemachineVirtualCamera cam;

    [SerializeField]
    private UnityEvent dEvent;

    [SerializeField]
    private UnityEvent dEvent2;

    private int story = 0;

    public void Talk()
    {

        if (GameManager.Instance.IsCurCursor("Research"))//커서가 조사일때
        {
            if (story == 0)
            {
                TalkManager.Instance.cam = cam;
                TalkManager.Instance.curLogIndex = 0;
                TalkManager.Instance.curDlog = dialogue;
                TalkManager.Instance.dEvent = dEvent;
                TalkManager.Instance.Talk();

                story = 1;
            }
            else if (story == 1)
            {
                TalkManager.Instance.cam = cam;
                TalkManager.Instance.curLogIndex = 0;
                TalkManager.Instance.curDlog = dialogue2;
                TalkManager.Instance.dEvent = dEvent2;
                TalkManager.Instance.Talk();

                story = 2;
            }
            
        }
    

    }

    public void DEvent1()
    {
        InputManager.Instance.ChangeState(StateName.MiniGame);

        
    }

    public void DEvent2()
    {
        cam.Priority = 1;
        //대화모드 해제
        InputManager.Instance.ChangeState(StateName.Idle);
        TalkManager.Instance.RenderQuestText("F1키를 눌러 상처를 내고 얻은 보석을 노인에게 건네자.");
    }
}
