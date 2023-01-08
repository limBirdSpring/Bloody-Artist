using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBGMToPlaying : MonoBehaviour
{
    [SerializeField]
    private BGMSound bgm;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            if (SoundManager.Instance.curBGM == BGMSound.Playing)
            {
                SoundManager.Instance.SetBgm(bgm);
            }
            else
            {
                SoundManager.Instance.SetBgm(BGMSound.Playing);
            }
        }
    }
}
