using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sitable : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera cam;

    [HideInInspector]
    public bool isExpGetable = false;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private Animator anim2;


    public void Sit()
    {
        if (ItemManager.Instance.curSetItem.fileName == "Research")
        {
            GetComponent<AudioSource>().Play();
            InputManager.Instance.ChangeState(StateName.Block);
            cam.Priority = 20;
            StartCoroutine(SitCoroutine());
        }
    }

    private IEnumerator SitCoroutine()
    {
        yield return new WaitForSeconds(3f);
        BloodManager.Instance.Heal(10);
        GetComponent<AudioSource>().Play();
        InputManager.Instance.ChangeState(StateName.Idle);
        cam.Priority = 1;

        if (isExpGetable)
        {
            ExpManager.Instance.AddExp("Green");
            anim.SetBool("IsOpen", true);
            anim2.SetBool("IsOpen", true);
            isExpGetable = false;
        }

    }
}
