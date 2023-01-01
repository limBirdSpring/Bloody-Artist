using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
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

    private string prevText;


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

    private int curLogIndex =0;

    public Dialogue curDlog;

    private AudioSource audio;

    [SerializeField]
    private AudioClip nextSFX;


    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

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
            if (!isTexting)
            {
                curLogIndex++;
            }

            if (talkCanvas.gameObject.activeSelf == false)
            {
                //대화창 보이게하기 + 효과음
                talkCanvas.gameObject.SetActive(true);

                //대화모드 (Player Input 설정)
                PlayerInput.Instance.isTalking = true;
            }

            audio.clip = nextSFX;
            audio.Play();
            nameText.text = curDlog.dialogue[curLogIndex-1].name;
            TextFlow(dialogueText, curDlog.dialogue[curLogIndex-1].log);

        }
        else if (!isTexting)
        {
            talkCanvas.GetComponentInChildren<Animator>().SetTrigger("Close");
            StartCoroutine(CanvasActive());

            curLogIndex = 0;

            //대화모드 해제
            PlayerInput.Instance.isTalking = false;
        }

    }

    private IEnumerator CanvasActive()
    {
        yield return new WaitForSeconds(1f);
        talkCanvas.gameObject.SetActive(false);
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
