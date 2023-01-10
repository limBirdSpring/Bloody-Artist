using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talkable : MonoBehaviour
{
    [SerializeField]
    private Dialogue dialogue;

    private int index = 0;

    public void Talk()
    {
        if(GameManager.Instance.IsCurCursor("Research"))//커서가 조사일때
        {

            if (index != 0)
            {
                if (dialogue.dialogue.Count > index && !TalkManager.Instance.isTexting)
                    index++;
                else if (dialogue.dialogue.Count <= index)
                    index = 0;
            }

            TalkManager.Instance.curDlog = dialogue;
            TalkManager.Instance.Talk(index);


            if (index == 0)
                index++;


        }

    }
}
