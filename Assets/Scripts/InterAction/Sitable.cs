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
            GameManager.Instance.brain.m_DefaultBlend.m_Time = 2f;
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
        yield return new WaitForSeconds(2f);
        GameManager.Instance.brain.m_DefaultBlend.m_Time = 0.5f;

        if (isExpGetable)
        {
            ExpManager.Instance.AddExp("Green");
            anim.gameObject.GetComponent<AudioSource>().Play();
            anim.SetBool("IsOpen", true);
            anim2.gameObject.GetComponent<AudioSource>().Play();
            anim2.SetBool("IsOpen", true);
            isExpGetable = false;
        }

    }
}
