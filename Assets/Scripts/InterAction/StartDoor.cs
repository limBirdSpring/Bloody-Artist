using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDoor : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Open()
    {
        if (ItemManager.Instance.curSetItem.fileName == "Knife")
        {
            GetComponent<AudioSource>().Play();
            anim.SetTrigger("Open");
        }
    }
}
