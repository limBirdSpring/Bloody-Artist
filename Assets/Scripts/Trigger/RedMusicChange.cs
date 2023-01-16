using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMusicChange : MonoBehaviour
{
    [SerializeField]
    private AudioSource audio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            audio.volume = 1;
            SoundManager.instance.SetBgm(BGMSound.None);
            Destroy(gameObject);
        }
    }
}
