using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera cam1;

    [SerializeField]
    private CinemachineVirtualCamera cam2;

    [SerializeField]
    private CinemachineVirtualCamera cam3;

    [SerializeField]
    private CinemachineVirtualCamera cam4;

    private void Start()
    {
        StartCoroutine(Cor());
    }

    private IEnumerator Cor()
    {
        yield return new WaitForSeconds(4f);
        cam2.Priority = 20;

        yield return new WaitForSeconds(4f);
        cam3.Priority = 30;

        yield return new WaitForSeconds(4f);
        cam4.Priority = 40;

        yield return new WaitForSeconds(4f);
        //ÆäÀÌµå¾Æ¿ô
    }


}
