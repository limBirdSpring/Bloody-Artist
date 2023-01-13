using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFePill : MonoBehaviour
{
    public void DrinkFePill()
    {
        TalkManager.Instance.EraseQuestText();
        TalkManager.Instance.RenderText("C o m p l e t e");

        TalkManager.Instance.RenderQuestText("ESC키를 눌러 조작방법을 확인하고, 철분제를 먹어보자.");
    }
}
