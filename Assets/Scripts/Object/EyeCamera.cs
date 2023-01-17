using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EyeCamera : SingleTon<EyeCamera>
{
    private int hp = 100;

    [SerializeField]
    private GameObject door;


    [SerializeField]
    private AudioSource audio;

    [SerializeField]
    private AudioClip clip;

    public bool horrorOn { get; private set; } = false;

    private Coroutine coroutine;

    private void Start()
    {
        coroutine = StartCoroutine(ChangePos());
    }

    public void Hurt()
    {
        hp -= 100;

        if (hp <= 0)
        {
            //군중소리/노래소리 변경
            SoundManager.Instance.SetBgm(BGMSound.WhiteSilence_Red);

            audio.clip = clip;

            StopCoroutine(coroutine);
            horrorOn = true;

            door.SetActive(true);
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private IEnumerator ChangePos()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            transform.position = new Vector3(Random.Range(-47,-26), 7f, Random.Range(199, 226));
        }
    }
}
