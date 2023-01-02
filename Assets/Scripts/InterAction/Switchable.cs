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
        if (GameManager.Instance.IsCurCursor("Research"))//커서가 조사일때
        {
            GetComponent<AudioSource>()?.Play();
            anim.SetBool("IsOn", !anim.GetBool("IsOn"));
        }
    }

}
