using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtistMusicOn : MonoBehaviour
{
    [SerializeField]
    private AudioSource redBgm;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            SoundManager.Instance.SetBgm(BGMSound.Classic);
            redBgm.Play();
            Destroy(gameObject);
            
        }
    }
}
