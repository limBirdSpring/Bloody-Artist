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
        if (GameManager.Instance.IsCurCursor("Knife") && isOn == false)
        {
            GetComponent<AudioSource>().Play();
            //ƒÆ¿Ã ¿÷¿ª ∂ß
            isOn = true;
            half.SetActive(true);
            all.SetActive(false);

            ElecManager.Instance.ElecUpdate(this.GetComponent<Elecable>());

        }
    }

    public void Off()
    {
        isOn = false;
        half.SetActive(false);
        all.SetActive(true);
    }
}
