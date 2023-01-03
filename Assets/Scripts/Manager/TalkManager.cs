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

    //--------------------흐르는 텍스트 관련---------------------
    private bool isTexting;
    private Coroutine curCoroutine;

    private string prevText = "";


    //--------------------아이템 획득 텍스트---------------------
    [SerializeField]
    private TextMeshProUGUI getTextUI;



    //-------------------------대화 관련------------------------
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


    //-------------------------조사 관련------------------------

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
    //                     흐르는 텍스트
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
    //                          대화
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
                //대화창 보이게하기
                talkCanvas.gameObject.SetActive(true);

                //대화모드
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

            //대화모드 해제
            InputManager.Instance.ChangeState(StateName.Idle);
        }


    }

    private IEnumerator CanvasActive()
    {
        yield return new WaitForSeconds(1f);
        talkCanvas.gameObject.SetActive(false);
    }


    //==========================================================
    //                          조사
    //==========================================================


    public void ShowResearchText()
    {
        Vector2 mousePos = Input.mousePosition;

        Vector2 windowMiddle = new Vector2(Screen.width *0.5f, Screen.height * 0.5f);

        if (mousePos.x < windowMiddle.x && mousePos.y > windowMiddle.y)//1분할
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

        researchTMP.transform.position = mousePos;//해당 마우스 위치로 변경

        InputManager.Instance.ChangeState(StateName.Researching);

        //사분할 중 마우스 포지션을 받아, 해당 조사오브젝트를 출력함.
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
    //                 아이템/경험 얻기 텍스트
    //==========================================================

    public void RenderGetItemText(ItemInfo item)
    {
        getTextUI.gameObject.SetActive(false);
        getTextUI.color = new Color(32, 32, 32, 1);
        getTextUI.text = "『" + item.name + "』" + " 아이템을 얻었다.";
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
                name = "치장";
                color = new Color(106, 24, 94, 1);
                break;
            case "Yellow":
                name = "공포";
                color = new Color(255, 208, 0, 1);
                break;
            case "Blue":
                name = "고독";
                color = new Color(24, 34, 106, 1);
                break;
            case "Green":
                name = "휴식";
                color = new Color(0, 234, 5, 1);
                break;
            case "White":
                name = "불안";
                color = new Color(255, 255, 255, 1);
                break;
            case "Black":
                name = "탄회";
                color = new Color(0, 0, 0, 1);
                break;
        }
        //각 경험에 따라 다른 색상으로 출력
        getTextUI.color = color;
        getTextUI.text = "『" + name + "』" + " 경험을 얻었다.";
        getTextUI.gameObject.SetActive(true);
    }



}
