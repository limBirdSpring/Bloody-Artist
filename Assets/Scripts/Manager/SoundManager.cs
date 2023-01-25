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
    FallDown,
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
    WhiteSilence_Red,
    Size
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

    public void SetBgm(BGMSound name, float time = 0.5f)
    {
        if (name == curBGM)
            return;

        AudioClip clip = null;

        for (int i = 0; i < bgms.Count; i++)
        {
            if (bgms[i].bgmSound == name)
            {
                clip = bgms[i].clip;
                curBGM = name;
            }
           
        }
        //점점 소리 줄이기
        StartCoroutine(FadeCor(clip, time));

    }

    private IEnumerator FadeCor(AudioClip clip, float time)
    {
        while (bgmAudio.volume > 0.1f)
        {
            yield return new WaitForSeconds(0.01f);
            bgmAudio.volume -= 1 / (time / 0.01f);
        }

        yield return new WaitForSeconds(0.2f);
        bgmAudio.clip = clip;
        bgmAudio.Play();

        while (bgmAudio.volume < 0.99f)
        {
            yield return new WaitForSeconds(0.01f);
            bgmAudio.volume += 1 / (time / 0.01f);
        }
    }
}
