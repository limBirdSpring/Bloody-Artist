using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager :  SingleTon<GameManager>
{

    public bool isRunMode { get; private set; }//런모드 변경 (get,set)

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

    [SerializeField]
    private CinemachineVirtualCamera gameOverCam;

    [SerializeField]
    private Image gameOverImg;

    [SerializeField]
    private Button gameOverButton;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Transform loadPlayerPos;

    [SerializeField]
    private CinemachineBrain brain;

    [HideInInspector]
    public int story =0;

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


    public void StartRunMode()
    {
        isRunMode = true;
        SoundManager.Instance.SetBgm(BGMSound.Run);
    }

    public void EndRunMode()
    {
        isRunMode = false;
        SoundManager.Instance.SetBgm(BGMSound.Playing);
    }



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

    StateName curState;

    private IEnumerator GameOverCor()
    {
        gameOverCam.Priority = 30;
        yield return new WaitForSeconds(2f);

        //게임오버 화면 출력 후 시간 멈추기, 상태 블락 -> 버튼 누르면 원래대로
        gameOverImg.gameObject.SetActive(true);
        player.transform.position = loadPlayerPos.position;
        brain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;

        curState = InputManager.Instance.GetCurState();

        InputManager.Instance.ChangeState(StateName.Block);

        //플레이어 위치 조정, 상처도, 피로도 조정
        BloodManager.Instance.ResetBlood();

        //버튼 띄우기
        InputManager.Instance.ChangeState(StateName.BlockResearch);
        gameOverButton.gameObject.SetActive(true);
        gameOverCam.Priority = 1;
        Time.timeScale = 0;
    }


    public void GameOver()
    {
        SoundManager.Instance.UIAudioPlay(UISound.GameOver);
        StartCoroutine(GameOverCor());

    }

    public void GameOverButton()
    {
        Time.timeScale = 1;
        brain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.EaseInOut;
        gameOverImg.gameObject.SetActive(false);
        StartCoroutine(ButtonCor());
    }

    private IEnumerator ButtonCor()
    {
        yield return new WaitForSeconds(0.5f);
        InputManager.Instance.ChangeState(curState);
    }


    public void SceneChange(string sceneName)
    {
        //씬 체인지
        SceneManager.LoadScene(sceneName);
    }


}



