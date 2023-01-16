using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story_Mirror : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera backCam;

    [SerializeField]
    private GameObject artist;

    [SerializeField]
    private GameObject mirror;

    [SerializeField]
    private AudioSource audio;

    public void MirrorStory()
    {
        if (audio != null)
        {
            audio.volume = 1;
            SoundManager.instance.SetBgm(BGMSound.None);
        }

        StartCoroutine(StoryCoroutine());


    }
    private IEnumerator StoryCoroutine()
    {
        yield return new WaitForSeconds(2f);

        InputManager.Instance.ChangeState(StateName.Block);

        GameManager.Instance.brain.m_DefaultBlend.m_Time = 2;
        backCam.Priority = 20;
        yield return new WaitForSeconds(2f);

        artist.SetActive(false);
        mirror.SetActive(true);

        yield return new WaitForSeconds(2f);

        // 쿠궁 소리
        GetComponent<AudioSource>().Play();
        GameManager.Instance.brain.m_DefaultBlend.m_Time = 0.5f;
        backCam.Priority = 1;

        yield return new WaitForSeconds(5f);

        while(BloodManager.Instance.hurtPercent <=99)
        {
            yield return new WaitForSeconds(0.3f);
            BloodManager.Instance.Hurt(10);
        }

        // 카메라 뒤로 넘어가기

        //화면 페이드

        //글 출력

    }
}
