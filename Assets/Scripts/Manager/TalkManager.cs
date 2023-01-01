using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using static UnityEditor.Progress;
using Color = UnityEngine.Color;

public class TalkManager : SingleTon<TalkManager>
{
    private bool isTexting;
    private Coroutine curCoroutine;

    [SerializeField]
    private TextMeshProUGUI getTextUI;


    //흐르는 텍스트
    public void TextFlow(TextMeshProUGUI textMeshpro, string text)
    {
        if (!isTexting)
        {
            textMeshpro.text = "";
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


    //획득 텍스트 출력
    public void RenderGetItemText(ItemInfo item)
    {
        getTextUI.color = new Color(32, 32, 32, 1);
        getTextUI.text = "『" + item.name + "』" + " 아이템을 얻었다.";
        getTextUI.gameObject.SetActive(true);
    }

    public void RenderGetExpText(string colorName)
    {
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
