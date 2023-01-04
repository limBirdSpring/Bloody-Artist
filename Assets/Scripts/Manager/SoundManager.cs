using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum UISound
{
    Inven,
    Paper,
    ItemSet,
    Click,
    Next,
    ScreenOn,
    Drink,
    Horror,
    GetItem,
    UsedKnife,
    Hurt,
    Punch,
    Size
}

[Serializable]
public struct UISFX
{
    public UISound uiSound;
    public AudioClip clip;
}


public class SoundManager : SingleTon<SoundManager>
{
    public List<UISFX> uiSFXes;

    private AudioSource uiAudio;

    [SerializeField]
    private AudioSource bgmAudio;


    private void Awake()
    {
        uiAudio = GetComponent<AudioSource>();
    }


    public void UIAudioPlay(UISound name)
    {
        for(int i = 0; i < uiSFXes.Count; i++)
        {
            if (uiSFXes[i].uiSound == name)
               uiAudio.clip = uiSFXes[i].clip;
        }
        uiAudio.Play();
    }

    public void JustAudioPlay(AudioClip clip)
    {
        uiAudio.clip = clip;
        uiAudio.Play();
    }

}
