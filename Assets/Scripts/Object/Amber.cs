using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amber : MonoBehaviour
{
    [SerializeField]
    private Light light;

    [SerializeField]
    private Light light2;

    [SerializeField]
    private ManequinControler manequin;

    public void Trauma()
    {

        StartCoroutine(TraumaCoroutine());
    }

    private IEnumerator TraumaCoroutine()
    {
        SoundManager.Instance.SetBgm(BGMSound.None);
        yield return new WaitForSeconds(1f);
        light2.GetComponent<AudioSource>().Play();
        light.intensity = 0.1f;
        light2.intensity = 0.1f;

        yield return new WaitForSeconds(0.5f);

        light.intensity = 3f;
        light2.intensity = 3f;

        yield return new WaitForSeconds(0.5f);

        light.GetComponent<AudioSource>().Play();
        light.intensity = 0f;
        light2.intensity = 0f;

        yield return new WaitForSeconds(2f);

        GameManager.Instance.StartRunMode();
        manequin.isMove = true;

    }
}
