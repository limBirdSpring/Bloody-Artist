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
    Good,
    GameOver,
    Size
}



[Serializable]
public struct UISFX
{
    public UISound uiSound;
    public AudioClip clip;
}

public enum BGMSound
{
    Playing,
    Exhibition,
    Run,
    RunFast,
    Classic,
    Classic_Red,
    Ending,
    WhiteSilence,
    None,
}

[Serializable]
public struct BGM
{
    public BGMSound bgmSound;
    public AudioClip clip;
}


public class SoundManager : SingleTon<SoundManager>
{
    public List<UISFX> uiSFXes;
    public List<BGM> bgms;

    private AudioSource uiAudio;

    public BGMSound curBGM { get; private set; } = BGMSound.Playing;

    [SerializeField]
    private AudioSource bgmAudio;


    private void Awake()
    {
        uiAudio = GetComponent<AudioSource>();
    }


    public void UIAudioPlay(UISound name)
    {
        for (int i = 0; i < uiSFXes.Count; i++)
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

    public void SetBgm(BGMSound name)
    {

        for (int i = 0; i < bgms.Count; i++)
        {
            if (bgms[i].bgmSound == name)
            {
                bgmAudio.clip = bgms[i].clip;
                curBGM = name;
            }
            bgmAudio.Play();
        }



    }
}
