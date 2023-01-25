using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager :  SingleTon<GameManager>
{

    public bool isRunMode { get; private set; }//런모드 변경 (get,set)

    //-----------------커서 관련----------------------

    [SerializeField]
    private Texture2D cursorImg;//커서이미지

    [SerializeField]
    private Texture2D researchCursor;

    [SerializeField]
    private Texture2D handCursor;

    [SerializeField]
    private Texture2D talkCursor;

    //------------------------------------------------

    [SerializeField]
    private Image bloodyScene;

    public PostProcessVolume tiredprofile;

    [HideInInspector]
    public DepthOfField tiredBlur;

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


    //----------------게임스타트씬------------------

    [SerializeField]
    private GameObject gameCanvas;

    [SerializeField]
    private GameObject canvas;

    [SerializeField]
    private GameObject canvas2;

    [SerializeField]
    private GameObject blackCanvas;


    //----------------------------------------------


    public CinemachineBrain brain;

    [HideInInspector]
    public int story =0;

    private void Awake()
    {
        tiredprofile.sharedProfile.TryGetSettings<DepthOfField>(out tiredBlur);
    }

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

    public void CursorChange(string name)
    {
        switch(name)
        {
            case "normal":
                CursorChange(cursorImg);
                break;
            case "research":
                CursorChange(researchCursor);
                break;
            case "item":
                CursorChange(handCursor);
                break;
            case "Talk":
                CursorChange(talkCursor);
                break;
        }
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
        SoundManager.Instance.SetBgm(BGMSound.Run, 0);
    }

    public void EndRunMode()
    {
        isRunMode = false;
        SoundManager.Instance.SetBgm(BGMSound.Playing, 0);
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
        Debug.Log("골 : " + goal);

        if (tiredBlur.focalLength.value < goal)
       {
            while (tiredBlur.focalLength.value < goal )
           {
               //증가
               yield return new WaitForSeconds(0.1f);
               tiredBlur.focalLength.value += 1;
           }
       }
       else
       {
           while( tiredBlur.focalLength.value > goal)
           {
                Debug.Log("블러 : " + tiredBlur.focalLength.value);
                //감소
                yield return new WaitForSeconds(0.1f);
               tiredBlur.focalLength.value -= 1;
           }
       }
   
   }

    StateName curState;
    BGMSound curBGM;

    public void GameOver()
    {
        curBGM = SoundManager.Instance.curBGM;
        SoundManager.Instance.SetBgm(BGMSound.None, 0);
        SoundManager.Instance.UIAudioPlay(UISound.GameOver);
        StartCoroutine(GameOverCor());

    }

    private IEnumerator GameOverCor()
    {
        gameOverCam.Priority = 30;
        yield return new WaitForSeconds(2f);
        SoundManager.Instance.UIAudioPlay(UISound.FallDown);

        //게임오버 화면 출력 후 시간 멈추기, 상태 블락 -> 버튼 누르면 원래대로
        gameOverImg.gameObject.SetActive(true);
        player.transform.position = loadPlayerPos.position;
        brain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;

        curState = InputManager.Instance.GetCurState();

        InputManager.Instance.ChangeState(StateName.Block);

        //플레이어 위치 조정, 상처도, 피로도 조정
        BloodManager.Instance.ResetBlood();

        yield return new WaitForSeconds(1f);

        //버튼 띄우기
        InputManager.Instance.ChangeState(StateName.BlockResearch);
        gameOverButton.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
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
        gameOverCam.Priority = 1;
        SoundManager.Instance.SetBgm(curBGM, 0);
        InputManager.Instance.ChangeState(curState);
    }


    public void SceneChange(string sceneName)
    {
        //씬 체인지
        SceneManager.LoadScene(sceneName);
    }



    public void StartGameScene()
    {
        StartCoroutine(LoadSceneNow());
    }

    private IEnumerator LoadSceneNow()
    {

        yield return new WaitForSeconds(3f);
        canvas.SetActive(true);
        gameCanvas.SetActive(false);
        yield return new WaitForSeconds(5f);
        canvas2.SetActive(true);
        yield return new WaitForSeconds(1f);
        //화면 검게
        blackCanvas.SetActive(true);
        yield return new WaitForSeconds(1f);
        GameManager.Instance.SceneChange("MainMap");
    }

    public void GameExit()
    {
        Application.Quit();
    }

}



