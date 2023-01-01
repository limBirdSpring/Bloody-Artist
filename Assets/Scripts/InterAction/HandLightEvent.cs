using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLightEvent : MonoBehaviour
{
    [SerializeField]
    private Light light;

    [SerializeField]
    private AudioClip clip;

    public void HandlightOn()
    {
        light.intensity = 1.92f;
        PlayerInput.Instance.audio.clip = clip;
        PlayerInput.Instance.audio.Play();
    }

}