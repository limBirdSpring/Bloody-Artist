using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFePill : MonoBehaviour
{
    public void DrinkFePill()
    {
        TalkManager.Instance.EraseQuestText();
        TalkManager.Instance.RenderText("C o m p l e t e");

        TalkManager.Instance.RenderQuestText("ESCŰ�� ���� ���۹���� Ȯ���ϰ�, ö������ �Ծ��.");
    }
}
