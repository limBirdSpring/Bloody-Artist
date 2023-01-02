using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talkable : MonoBehaviour
{
    [SerializeField]
    private Dialogue dialogue;

    public void Talk()
    {
        if(GameManager.Instance.IsCurCursor("Research"))//Ŀ���� �����϶�
        {
            TalkManager.Instance.curDlog = dialogue;
            TalkManager.Instance.Talk();
        }
    }
}
