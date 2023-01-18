using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardKeyDoorOpenable : MonoBehaviour
{
    [SerializeField]
    private Animator anim;


    public void CarKeyOpen()
    {
        if (GameManager.Instance.IsCurCursor("CardKey"))
        {
            GetComponent<AudioSource>()?.Play();
            anim.gameObject.GetComponent<AudioSource>()?.Play();
            anim.SetTrigger("Open");
        }
    }

}
