using System.Collections;
using System.Collections.Generic;
using System.Net.Cache;
using UnityEngine;
using UnityEngine.UI;

public class ExpManager : SingleTon<ExpManager>
{
    [SerializeField]
    private List<Image> expUI = new List<Image>();

    private List<string> haveExp = new List<string>();

    public void AddExp(string expColor)
    {
        //ȹ�� �ؽ�Ʈ ���
        TalkManager.Instance.RenderGetExpText(expColor);
        haveExp.Add(expColor);


        for(int i=0; i<expUI.Count;i++)
        {
            if (expUI[i].name == "ExpNote_" + expColor)
                expUI[i].gameObject.SetActive(true);
        }
    }

    public bool isExpHave(string expColor)
    {
        return haveExp.Contains(expColor);
    }


    public void DeleteExp(string expColor)
    {
        for (int i = 0; i < expUI.Count; i++)
        {
            if (expUI[i].name == "ExpNote_" + expColor)
                expUI[i].gameObject.SetActive(false);
        }
    }

    //��ư�� ������ �ش� UI�� ���� �տ� ���� ����
    public void SetExp(string expColor)
    {
        BloodManager.Instance.ChangeBloodColor(expColor);

        Image img = null;

        for (int i = 0; i < expUI.Count; i++)
        {
            if (expUI[i].name == "ExpNote_" + expColor)
                img = expUI[i];
        }

        img.gameObject.transform.SetAsLastSibling();
    }

}
