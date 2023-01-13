using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLightEvent : MonoBehaviour
{
    [SerializeField]
    private Light light;

    [SerializeField]
    private AudioClip clip;

    public void HandlightOn()
    {
        TalkManager.Instance.EraseQuestText();
        TalkManager.Instance.RenderText("C o m p l e t e");
        light.intensity = 1.92f;
        SoundManager.Instance.JustAudioPlay(clip);
        TalkManager.Instance.RenderQuestText("�Ͼ �� �� �ȵǾ ��������. ö������ �����..?");
    }
}