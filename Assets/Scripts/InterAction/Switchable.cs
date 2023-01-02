using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchable : MonoBehaviour
{

    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void SwitchOnOff()
    {
        GetComponent<AudioSource>().Play();
        anim.SetBool("IsOn", !anim.GetBool("IsOn"));
    }

}
