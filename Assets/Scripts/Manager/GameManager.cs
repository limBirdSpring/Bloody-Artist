using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager :  SingleTon<GameManager>
{

    private bool isRunMode;//����� ���� (get,set)

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

    [HideInInspector]
    public bool isHorrorMode; //�ش� ������ ���� ����ġ��尡 ������.

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



    public void GameOver()
    {
        //���ӿ��� ������ ��ȯ
        SceneChange("GameOver");
    }

    public void SceneChange(string sceneName)
    {
        //�� ü����
    }

    public void RunMode()//������� ��� ���� �� ȿ�� (Ư�� Ű ��� �Ұ� ��)
    {
    }


}



