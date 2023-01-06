using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class MaskManager : SingleTon<MaskManager>
{
    [HideInInspector]
    public int collect = 0;

    [SerializeField]
    private CinemachineVirtualCamera cam;

    private bool isTakable = false;

    public void Collection()
    {
        collect++;
        if (collect == 4)
            isTakable = true;
    }

    public void Take()
    {
        if (isTakable && GameManager.Instance.IsCurCursor("Research"))
        {
            InputManager.Instance.ChangeState(StateName.Block);
            cam.Priority = 20;
           
        }
        else if (GameManager.Instance.IsCurCursor("Research"))
        {
            TalkManager.Instance.researchText = "사진을 찍으면 바로 출력되는 형식의 폴라로이드 카메라다.";
            TalkManager.Instance.ShowResearchText();
        }
    }

    private IEnumerator TakeCoroutine()
    {
        yield return new WaitForSeconds(2f);

        GetComponent<AudioSource>().Play();
        StartCoroutine(TakeCoroutine());

        yield return new WaitForSeconds(2f);

        ItemManager.Instance.GetItem("Photo");

        isTakable = false;
        cam.Priority = 1;
        InputManager.Instance.ChangeState(StateName.Idle);
    }


}
