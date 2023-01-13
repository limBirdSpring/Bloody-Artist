using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Talkable : MonoBehaviour
{
    [SerializeField]
    private Dialogue dialogue;

    [SerializeField]
    private CinemachineVirtualCamera cam;

    public void Talk()
    {
        if(GameManager.Instance.IsCurCursor("Research") && ItemManager.Instance.FindItem("LightKey"))
        {
            TalkManager.Instance.cam = cam;
            TalkManager.Instance.curLogIndex = 0;
            TalkManager.Instance.curDlog = dialogue;
            TalkManager.Instance.dEvent = null;
            TalkManager.Instance.Talk();

        }

    }
}
