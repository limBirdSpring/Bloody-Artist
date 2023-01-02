using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenable : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    private string usedItemName;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Open()
    {
        if (ItemManager.Instance.curSetItem.fileName == usedItemName)
        {
            GetComponent<AudioSource>()?.Play();
            
            anim.SetTrigger("Open");
        }
    }
}
