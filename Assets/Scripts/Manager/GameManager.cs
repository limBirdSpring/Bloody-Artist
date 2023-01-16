using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager :  SingleTon<GameManager>
{

    public bool isRunMode { get; private set; }//����� ���� (get,set)

    [SerializeField]
    private Texture2D cursorImg;//Ŀ���̹���

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
        Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);//�⺻ Ŀ�� �̹���
    }


    //---------------------ī�޶� ����-----------------------

    public void ChangeCamToFront()
    {
        frontCam.Priority = 20;
    }

    public void ExitCamFromFront()
    {
        frontCam.Priority = 1;
    }




    //----------------------Ŀ�� ����------------------------

    public void CursorChange(Texture2D img)
    {
        Cursor.SetCursor(img, new Vector2((float)img.width*0.5f, (float)img.height*0.5f), CursorMode.ForceSoftware);
    }

    //���� Ŀ���� �Է��� ������ �̸��� Ŀ���ΰ�?
    public bool IsCurCursor(string fileName)
    {
        Debug.Log(fileName);
        Debug.Log(ItemManager.Instance.curSetItem.fileName);
        if (fileName == ItemManager.Instance.curSetItem.fileName)
            return true;
        else
            return false;
    }


    //----------------------�� ����------------------------


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
        //�������� ȭ�� ������ �ϱ�
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
                //����
                yield return new WaitForSeconds(0.1f);
                Color color = new Color(255, 255, 255, i);
                tiredScreen.color = color;
            }
        }
        else
        {
            for (float i = tiredScreen.color.a; i > goal; i -= 0.01f)
            {
                //����
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

        //���ӿ��� ȭ�� ��� �� �ð� ���߱�, ���� ��� -> ��ư ������ �������
        gameOverImg.gameObject.SetActive(true);
        player.transform.position = loadPlayerPos.position;
        brain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;

        curState = InputManager.Instance.GetCurState();

        InputManager.Instance.ChangeState(StateName.Block);

        //�÷��̾� ��ġ ����, ��ó��, �Ƿε� ����
        BloodManager.Instance.ResetBlood();

        //��ư ����
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
        //�� ü����
        SceneManager.LoadScene(sceneName);
    }


}



