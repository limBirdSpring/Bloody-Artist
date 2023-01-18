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
    private GameObject gemImage = null;

    [SerializeField]
    private string gemFileName2 = "";

    [SerializeField]
    private GameObject gemImage2 = null;

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

    [SerializeField]
    private GameObject smoke;

    [SerializeField]
    private Canvas worldCanvas;

    [SerializeField]
    private AudioSource audio;


    public void GiveGem()
    {
        if (gemFileName!="" && GameManager.Instance.IsCurCursor(gemFileName))
        {
            ItemManager.Instance.UsedItem(gemFileName);
            gemFileName = "";

            SoundManager.Instance.UIAudioPlay(UISound.Good);
            if (gemImage!=null)
                gemImage.SetActive(true);

        }
        else if (gemFileName != "" && GameManager.Instance.IsCurCursor(gemFileName2))
        {
            ItemManager.Instance.UsedItem(gemFileName2);
            gemFileName = "";

            SoundManager.Instance.UIAudioPlay(UISound.Good);
            if (gemImage2 != null)
                gemImage2.SetActive(true);
        }
        else if (!GameManager.Instance.IsCurCursor("Research"))
        {
            BloodManager.Instance.Hurt(10);
        }

        if (gemFileName == "" && gemFileName2 == "")
        {


            GameManager.Instance.story++;

            if (rope != null)
            {
                //밧줄이 사라지는 소리
                
               
                rope.SetActive(false);
            }
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
        
        cam.Priority = 1;
        //대화모드 해제
        InputManager.Instance.ChangeState(StateName.Idle);
        Instantiate(smoke, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }

    public void OldManLightOn()
    {
        light.gameObject.SetActive(true);
        cam.Priority = 1;

        //대화모드 해제
        InputManager.Instance.ChangeState(StateName.Idle);

        GameObject obj = Instantiate(key ,transform.position, transform.rotation);
        obj.name = "LightKey";

        Instantiate(smoke, transform.position, Quaternion.identity);
        Destroy(gameObject);

        worldCanvas.gameObject.SetActive(true);



    }


}
