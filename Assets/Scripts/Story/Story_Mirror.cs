using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story_Mirror : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera backCam;

    [SerializeField]
    private CinemachineVirtualCamera gameOverCam;

    [SerializeField]
    private GameObject artist;

    [SerializeField]
    private GameObject mirror;

    [SerializeField]
    private AudioSource audio;

    [SerializeField]
    private GameObject fade;

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

        yield return new WaitForSeconds(1f);

        //뒤에서 큰소리가 남 (문닫히는소리)
        SwitchControler.Instance.hallSwitch.SetBool("isOn", false);
        SwitchControler.Instance.SwitchUpdate();

        yield return new WaitForSeconds(3f);

        InputManager.Instance.ChangeState(StateName.Block);

        GameManager.Instance.brain.m_DefaultBlend.m_Time = 2;
        backCam.Priority = 20;
        yield return new WaitForSeconds(2f);

        artist.transform.Translate(Vector3.back * 200 * Time.deltaTime);
        mirror.SetActive(true);

        yield return new WaitForSeconds(5f);

        // 쿠궁 소리

        GameManager.Instance.brain.m_DefaultBlend.m_Time = 0.5f;
        backCam.Priority = 1;
        yield return new WaitForSeconds(0.5f);
        GetComponent<AudioSource>().Play();


        yield return new WaitForSeconds(5f);
        GameManager.Instance.brain.m_DefaultBlend.m_Time = 2f;
        gameOverCam.Priority = 30;

        while (BloodManager.Instance.hurtPercent <90)
        {
            yield return new WaitForSeconds(0.4f);
            BloodManager.Instance.Hurt(10);
        }

        // 카메라 뒤로 넘어가기
        yield return new WaitForSeconds(2f);

        //화면 페이드
        fade.SetActive(true);

        yield return new WaitForSeconds(3f);

        //쓰러지는 소리 출력

        SoundManager.Instance.SetBgm(BGMSound.None);

        yield return new WaitForSeconds(20f);

        //엔딩화면으로
        GameManager.Instance.SceneChange("Ending");
    }
}
