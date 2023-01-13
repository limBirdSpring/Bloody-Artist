using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenable : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    private string usedItemName;

    public bool miniGame;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Open()
    {
        if (ItemManager.Instance.curSetItem.fileName == usedItemName)
        {
            if (miniGame)
            {
  
                InputManager.Instance.ChangeState(StateName.MiniGame);
                miniGame = false;
            }

            else
            {
                anim.SetTrigger("Open");
                GetComponent<AudioSource>()?.Play();
                InputManager.Instance.ChangeState(StateName.Idle);
            }
           
        }
    }
}
