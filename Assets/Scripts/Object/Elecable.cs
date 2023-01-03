using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elecable : MonoBehaviour
{
    [SerializeField]
    private GameObject half;

    [SerializeField]
    private GameObject all;

    public bool isOn { get; private set; } = false;

    
    public void On()
    {
        //칼이 있을 때
        isOn = true;
        half.SetActive(true);
        all.SetActive(false);
    }

    public void Off()
    {
        isOn = false;
        half.SetActive(false);
        all.SetActive(true);
    }
}
