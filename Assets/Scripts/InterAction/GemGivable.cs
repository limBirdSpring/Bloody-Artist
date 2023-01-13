using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GemGivable : MonoBehaviour
{
    [SerializeField]
    private string gemFileName = "";

    [SerializeField]
    private string gemFileName2 = "";

    [SerializeField]
    private Dialogue dLog;

    [SerializeField]
    private CinemachineVirtualCamera cam;

    [SerializeField]
    private UnityEvent dEvent;

    [SerializeField]
    private Light light;

    [SerializeField]
    private GameObject key;

    [SerializeField]
    private GameObject rope;


    public void GiveGem()
    {
        if (gemFileName!="" && GameManager.Instance.IsCurCursor(gemFileName))
        {
            ItemManager.Instance.UsedItem(gemFileName);
            gemFileName = "";

        }
        else if (gemFileName != "" && GameManager.Instance.IsCurCursor(gemFileName2))
        {
            ItemManager.Instance.UsedItem(gemFileName2);
            gemFileName = "";
        }
        else if (!GameManager.Instance.IsCurCursor("Research"))
        {
            BloodManager.Instance.Hurt(10);
        }

        if (gemFileName == "" && gemFileName2 == "")
        {
            //밧줄이 사라지는 파티클
            rope.SetActive(false);

            TalkManager.Instance.EraseQuestText();

            TalkManager.Instance.cam = cam;
            TalkManager.Instance.curLogIndex = 0;
            TalkManager.Instance.curDlog = dLog;
            TalkManager.Instance.dEvent = dEvent;
            TalkManager.Instance.Talk();
            
        }

    }


    public void LightOn()
    {
        light.gameObject.SetActive(true);

        //마네킹이 사라지는 파티클
        Destroy(gameObject);
        cam.Priority = 1;
        //대화모드 해제
        InputManager.Instance.ChangeState(StateName.Idle);
    }

    public void OldManLightOn()
    {
        light.gameObject.SetActive(true);

        //마네킹이 사라지는 파티클
        Destroy(gameObject);
        cam.Priority = 1;
        //대화모드 해제
        InputManager.Instance.ChangeState(StateName.Idle);
        GameObject obj = Instantiate(key ,transform.position, transform.rotation);
        obj.name = "LightKey";
    }


}
