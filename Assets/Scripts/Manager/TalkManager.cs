using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using static UnityEditor.Progress;
using Color = UnityEngine.Color;
using Image = UnityEngine.UI.Image;

public class TalkManager : SingleTon<TalkManager>
{

    //--------------------�帣�� �ؽ�Ʈ ����---------------------
    private bool isTexting;
    private Coroutine curCoroutine;

    private string prevText = "";


    //--------------------������ ȹ�� �ؽ�Ʈ---------------------
    [SerializeField]
    private TextMeshProUGUI getTextUI;



    //-------------------------��ȭ ����------------------------
    [SerializeField]
    private Canvas talkCanvas;

    [SerializeField]
    private TextMeshProUGUI nameText;

    [SerializeField]
    private TextMeshProUGUI dialogueText;


    [SerializeField]
    private Button select;


    public int curLogIndex { get; set; } = -1;

    public Dialogue curDlog;


    //-------------------------���� ����------------------------

    [SerializeField]
    private GameObject rightUp;
    [SerializeField]
    private GameObject leftUp;
    [SerializeField]
    private GameObject rightDown;
    [SerializeField]
    private GameObject leftDown;

    private GameObject researchTMP;


    public string researchText { get; set; }



    //==========================================================
    //                     �帣�� �ؽ�Ʈ
    //==========================================================
    public void TextFlow(TextMeshProUGUI textMeshpro, string text)
    {
        if (!isTexting || text!=prevText)
        {
            if (curCoroutine !=null)
                StopCoroutine(curCoroutine);
            textMeshpro.text = "";
            prevText = text;
            curCoroutine = StartCoroutine(TextCoroutine(textMeshpro, text));
        }
        else
        {
            StopCoroutine(curCoroutine);
            textMeshpro.text = text;
            isTexting = false;
        }
    }

    private IEnumerator TextCoroutine(TextMeshProUGUI textMeshpro, string text)
    {
        isTexting = true;
        for (int i = 0; textMeshpro.text != text ; i++)
        {
            yield return new WaitForSeconds(0.05f);

            textMeshpro.text += text[i];
        }
        isTexting = false;
    }

    //==========================================================
    //                          ��ȭ
    //==========================================================

    public void Talk()
    {

        if (curDlog.dialogue.Count > curLogIndex)
        {
            if (select.gameObject.activeSelf == true && curDlog.dialogue[curLogIndex + 1].select == false)
            {

            }
            else if (curLogIndex>=0&& curDlog.dialogue[curLogIndex+1].select == true)
            {
                select.GetComponentInChildren<TextMeshProUGUI>().text = curDlog.dialogue[curLogIndex+1].log;
                select.gameObject.SetActive(true);
                return;
            }

            if (!isTexting)
            {
                curLogIndex++;
            }

            if (talkCanvas.gameObject.activeSelf == false)
            {
                //��ȭâ ���̰��ϱ�
                talkCanvas.gameObject.SetActive(true);

                //��ȭ���
                InputManager.Instance.ChangeState(StateName.Talking);
            }

            SoundManager.Instance.UIAudioPlay(UISound.Next);
        
            nameText.text = curDlog.dialogue[curLogIndex].name;
            TextFlow(dialogueText, curDlog.dialogue[curLogIndex].log);

        }
        else if (!isTexting)
        {
            talkCanvas.GetComponentInChildren<Animator>().SetTrigger("Close");
            StartCoroutine(CanvasActive());

            curLogIndex = -1;

            //��ȭ��� ����
            InputManager.Instance.ChangeState(StateName.Idle);
        }


    }

    private IEnumerator CanvasActive()
    {
        yield return new WaitForSeconds(1f);
        talkCanvas.gameObject.SetActive(false);
    }


    //==========================================================
    //                          ����
    //==========================================================


    public void ShowResearchText()
    {
        Vector2 mousePos = Input.mousePosition;

        Vector2 windowMiddle = new Vector2(Screen.width *0.5f, Screen.height * 0.5f);

        if (mousePos.x < windowMiddle.x && mousePos.y > windowMiddle.y)//1����
        {
            researchTMP = leftUp;
        }
        else if (mousePos.x > windowMiddle.x && mousePos.y > windowMiddle.y)
        {
            researchTMP = rightUp;
        }
        else if (mousePos.x < windowMiddle.x && mousePos.y < windowMiddle.y)
        {
            researchTMP = leftDown;
        }
        else if (mousePos.x > windowMiddle.x && mousePos.y < windowMiddle.y)
        {
            researchTMP = rightDown;
        }
        else
        {
            researchTMP = leftUp;
        }

        researchTMP.transform.position = mousePos;//�ش� ���콺 ��ġ�� ����

        InputManager.Instance.ChangeState(StateName.Researching);

        //����� �� ���콺 �������� �޾�, �ش� ���������Ʈ�� �����.
        researchTMP.SetActive(true);
        TextFlow(researchTMP.GetComponentInChildren<TextMeshProUGUI>(), researchText);
    }

    public void ExitResearchText()
    {
        if (!isTexting)
        {
            researchTMP.SetActive(false);
            InputManager.Instance.ChangeState(StateName.Idle);
        }
    }



    //==========================================================
    //                 ������/���� ��� �ؽ�Ʈ
    //==========================================================

    public void RenderGetItemText(ItemInfo item)
    {
        getTextUI.gameObject.SetActive(false);
        getTextUI.color = new Color(32, 32, 32, 1);
        getTextUI.text = "��" + item.name + "��" + " �������� �����.";
        getTextUI.gameObject.SetActive(true);
    }

    public void RenderGetExpText(string colorName)
    {
        getTextUI.gameObject.SetActive(false);
        string name = null;
        Color color = new Color(32, 32, 32, 1);

        switch(colorName)
        {
            case "Pink":
                name = "ġ��";
                color = new Color(106, 24, 94, 1);
                break;
            case "Yellow":
                name = "����";
                color = new Color(255, 208, 0, 1);
                break;
            case "Blue":
                name = "��";
                color = new Color(24, 34, 106, 1);
                break;
            case "Green":
                name = "�޽�";
                color = new Color(0, 234, 5, 1);
                break;
            case "White":
                name = "�Ҿ�";
                color = new Color(255, 255, 255, 1);
                break;
            case "Black":
                name = "źȸ";
                color = new Color(0, 0, 0, 1);
                break;
        }
        //�� ���迡 ���� �ٸ� �������� ���
        getTextUI.color = color;
        getTextUI.text = "��" + name + "��" + " ������ �����.";
        getTextUI.gameObject.SetActive(true);
    }



}
