using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField]
    private AudioSource audio;

    [SerializeField]
    private CinemachineVirtualCamera cam1;

    [SerializeField]
    private CinemachineVirtualCamera cam2;

    [SerializeField]
    private CinemachineDollyCart dolly2;


    [SerializeField]
    private CinemachineVirtualCamera cam3;

    [SerializeField]
    private CinemachineVirtualCamera cam4;

    [SerializeField]
    private CinemachineDollyCart dolly4;

    [SerializeField]
    private GameObject blackScene;

    private void Start()
    {
        //GameManager.Instance.brain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;
        StartCoroutine(Cor());
    }

    private IEnumerator Cor()
    {
        audio.Play();
        cam1.Priority = 20;

        yield return new WaitForSeconds(4.8f);
        cam2.Priority = 30;
        dolly2.m_Speed = 1;

        yield return new WaitForSeconds(8.3f);
        cam3.Priority = 40;

        yield return new WaitForSeconds(4f);
        cam4.Priority = 50;
        dolly4.m_Speed = 0.5f;


        yield return new WaitForSeconds(4f);
        //ÆäÀÌµå¾Æ¿ô
        blackScene.SetActive(true);


        yield return new WaitForSeconds(30f);
        GameManager.Instance.SceneChange("Title");


    }


}
