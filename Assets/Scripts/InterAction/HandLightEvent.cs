using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLightEvent : MonoBehaviour
{
    [SerializeField]
    private Light light;

    public void HandlightOn()
    {
        light.intensity = 1.92f;
    }
}
