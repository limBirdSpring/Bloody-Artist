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

    public void MirrorStory()
    {
        StartCoroutine(StoryCoroutine());


    }
    private IEnumerator StoryCoroutine()
    {
        InputManager.Instance.ChangeState(StateName.Block);

        backCam.Priority = 20;
        yield return new WaitForSeconds(2f);

        artist.SetActive(false);
        mirror.SetActive(true);

        yield return new WaitForSeconds(2f);

        backCam.Priority = 1;

        yield return new WaitForSeconds(5f);

        GameManager.Instance.GameOverCam();

        while(BloodManager.Instance.hurtPercent >=90)
        {
            yield return new WaitForSeconds(0.3f);
            BloodManager.Instance.Hurt(10);
        }

        //화면 페이드

    }
}
