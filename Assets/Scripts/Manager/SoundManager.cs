using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum UISound
{
    Inven,
    ItemSet,
    Click,
    Next,
    ScreenOn,
    Drink,
    Size
}


public class SoundManager : SingleTon<SoundManager>
{
    private AudioSource uiAudio;

    [SerializeField]
    private AudioSource bgmAudio;

    [SerializeField]
    private AudioClip inven;

    [SerializeField]
    private AudioClip itemSet;

    [SerializeField]
    private AudioClip click;

    [SerializeField]
    private AudioClip next;

    [SerializeField]
    private AudioClip screenOn;

    [SerializeField]
    private AudioClip drink;


    private void Awake()
    {
        uiAudio = GetComponent<AudioSource>();
    }


    public void UIAudioPlay(UISound name)
    {
        switch(name)
        {
            case UISound.Inven:
                uiAudio.clip = inven;
                break;
            case UISound.ItemSet:
                uiAudio.clip = itemSet;
                break;
            case UISound.Click:
                uiAudio.clip = click;
                break;
            case UISound.Next:
                uiAudio.clip = next;
                break;
            case UISound.Drink:
                uiAudio.clip = drink;
                break;
            case UISound.ScreenOn:
                uiAudio.clip = screenOn;
                break;
        }
        uiAudio.Play();
    }

}
