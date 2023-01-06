using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager :  SingleTon<GameManager>
{

    private bool isRunMode;//런모드 변경 (get,set)

    [SerializeField]
    private Texture2D cursorImg;//커서이미지

    [SerializeField]
    private Image bloodyScene;

    [SerializeField]
    private Image tiredScreen;

    [SerializeField]
    private CinemachineVirtualCamera frontCam;

    [SerializeField]
    private Image horrorImage;

    [HideInInspector]
    public bool isHorrorMode; //해당 변수에 따라 리서치모드가 막힌다.

    private void Start()
    {
        Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);//기본 커서 이미지
    }


    //---------------------카메라 관련-----------------------

    public void ChangeCamToFront()
    {
        frontCam.Priority = 20;
    }

    public void ExitCamFromFront()
    {
        frontCam.Priority = 1;
    }




    //----------------------커서 변경------------------------

    public void CursorChange(Texture2D img)
    {
        Cursor.SetCursor(img, new Vector2((float)img.width*0.5f, (float)img.height*0.5f), CursorMode.ForceSoftware);
    }

    //현재 커서가 입력한 아이템 이름의 커서인가?
    public bool IsCurCursor(string fileName)
    {
        Debug.Log(fileName);
        Debug.Log(ItemManager.Instance.curSetItem.fileName);
        if (fileName == ItemManager.Instance.curSetItem.fileName)
            return true;
        else
            return false;
    }


    //----------------------씬 관련------------------------


    public void HorrorImage(Sprite img)
    {
        if (IsCurCursor("Research"))
        {
            SoundManager.Instance.UIAudioPlay(UISound.Horror);

            horrorImage.sprite = img;
            horrorImage.gameObject.SetActive(true);

            StartCoroutine(ActFalse());
        }
    }

    private IEnumerator ActFalse()
    {
        yield return new WaitForSeconds(0.5f);
        horrorImage.gameObject.SetActive(false);
       // BloodManager.Instance.Hurt(5);

    }

    public void BloodyScene()
    {
        //다쳤을때 화면 빨갛게 하기
        bloodyScene.gameObject.SetActive(true);

        StartCoroutine(BloodySceneActive());
    }

    private IEnumerator  BloodySceneActive()
    {
        yield return new WaitForSeconds(0.15f);
        bloodyScene.gameObject.SetActive(false);
    }

    public void Blind(float goal)
    {
        StartCoroutine(BlindCoroutine(goal));
    }

    private IEnumerator BlindCoroutine(float goal)
    {
        if (tiredScreen.color.a < goal)
        {
            for(float i= tiredScreen.color.a; i < goal ; i+=0.01f)
            {
                //증가
                yield return new WaitForSeconds(0.1f);
                Color color = new Color(255, 255, 255, i);
                tiredScreen.color = color;
            }
        }
        else
        {
            for (float i = tiredScreen.color.a; i > goal; i -= 0.01f)
            {
                //감소
                yield return new WaitForSeconds(0.1f);
                Color color = new Color(255, 255, 255, i);
                tiredScreen.color = color;
            }
        }

    }



    public void GameOver()
    {
        //게임오버 씬으로 전환
        SceneChange("GameOver");
    }

    public void SceneChange(string sceneName)
    {
        //씬 체인지
    }

    public void RunMode()//술래잡기 모드 변경 시 효과 (특정 키 사용 불가 등)
    {
    }


}



