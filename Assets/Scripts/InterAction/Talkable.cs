using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talkable : MonoBehaviour
{
    [SerializeField]
    private Dialogue dialogue;

    public void Talk()
    {
        if(GameManager.Instance.IsCurCursor("Research"))//커서가 조사일때
        {
            TalkManager.Instance.curDlog = dialogue;
            TalkManager.Instance.Talk();
        }
    }
}
