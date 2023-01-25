using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    [SerializeField]
    private AudioMixer mixer;

    [SerializeField]
    private string volumeName;

    [SerializeField]
    private Slider slider;
    
    public void AudioControl()
    {
        float sound = slider.value;

        if (sound == -40f)
            mixer.SetFloat(volumeName, -80);
        else
            mixer.SetFloat(volumeName, sound);
    }

    public void AudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }

}
