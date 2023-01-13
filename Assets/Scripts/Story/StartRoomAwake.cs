using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoomAwake : MonoBehaviour
{

    private void Start()
    {
        
        //블러에서 점점 밝아짐
        StartCoroutine(PlayerAwake());
    }

    private IEnumerator PlayerAwake()
    {

        yield return new WaitForSeconds(2.5f);

        GetComponent<AudioSource>().Play();


        yield return new WaitForSeconds(0.5f);
        GetComponent<CinemachineVirtualCamera>().Priority = 1;

        yield return new WaitForSeconds(2f);
        InputManager.Instance.ChangeState(StateName.Idle);
        TalkManager.Instance.RenderQuestText("여긴..");

        yield return new WaitForSeconds(3f);
        SoundManager.Instance.UIAudioPlay(UISound.Hurt);
        GameManager.Instance.BloodyScene();
        TalkManager.Instance.RenderQuestText("윽! 상처가..");

        yield return new WaitForSeconds(2f);
        TalkManager.Instance.EraseQuestText();

        yield return new WaitForSeconds(3f);
        TalkManager.Instance.RenderQuestText("너무 어둡다. 주변을 밝힐만한 게 없을까?");

        yield return new WaitForSeconds(7f);
        TalkManager.Instance.RenderQuestText("Alt키를 누르고있으면 조사모드에 돌입한다. 손전등을 얻어 주변을 밝히자.");

        Destroy(gameObject);

    }
}
