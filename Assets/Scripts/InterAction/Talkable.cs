using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talkable : MonoBehaviour
{
    [SerializeField]
    private Dialogue dialogue;

    public void Talk()
    {
        TalkManager.Instance.curDlog = dialogue;
        TalkManager.Instance.Talk();
        
    }
}
