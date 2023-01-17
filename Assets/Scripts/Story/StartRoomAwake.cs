using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoomAwake : MonoBehaviour
{

    private void Start()
    {
        
        //������ ���� �����
        StartCoroutine(PlayerAwake());
    }

    private IEnumerator PlayerAwake()
    {

        yield return new WaitForSeconds(2.5f);

        GameManager.Instance.brain.m_DefaultBlend.m_Time = 2f;
        GetComponent<AudioSource>().Play();


        yield return new WaitForSeconds(0.5f);
        GetComponent<CinemachineVirtualCamera>().Priority = 1;

        yield return new WaitForSeconds(2f);
        InputManager.Instance.ChangeState(StateName.Idle);
        TalkManager.Instance.RenderQuestText("����..");

        yield return new WaitForSeconds(3f);
        SoundManager.Instance.UIAudioPlay(UISound.Hurt);
        GameManager.Instance.BloodyScene();
        TalkManager.Instance.RenderQuestText("��! ��ó��..");

        GameManager.Instance.brain.m_DefaultBlend.m_Time = 0.5f;

        yield return new WaitForSeconds(2f);
        TalkManager.Instance.EraseQuestText();

        yield return new WaitForSeconds(3f);
        TalkManager.Instance.RenderQuestText("�ʹ� ��Ӵ�. �ֺ��� �������� �� ������?");

        yield return new WaitForSeconds(7f);
        TalkManager.Instance.RenderQuestText("AltŰ�� ������������ �����忡 �����Ѵ�. �������� ��� �ֺ��� ������.");

        Destroy(gameObject);

    }
}
