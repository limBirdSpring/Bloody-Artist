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
        if (GameManager.Instance.IsCurCursor("Research"))//Ŀ���� �����϶�
        {
            GetComponent<AudioSource>()?.Play();
            anim.SetBool("IsOn", !anim.GetBool("IsOn"));
        }
    }

}
