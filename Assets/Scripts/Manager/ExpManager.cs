using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpManager : SingleTon<ExpManager>
{
    [SerializeField]
    private List<Image> expUI = new List<Image>(); 

    public void AddExp(string expColor)
    {
        //획득 텍스트 출력

        for(int i=0; i<expUI.Count;i++)
        {
            if (expUI[i].name == "ExpNote_" + expColor)
                expUI[i].gameObject.SetActive(true);
        }
    }

    public void DeleteExp(string expColor)
    {
        for (int i = 0; i < expUI.Count; i++)
        {
            if (expUI[i].name == "ExpNote_" + expColor)
                expUI[i].gameObject.SetActive(false);
        }
    }

    //버튼을 누르면 해당 UI가 가장 앞에 오게 만듬
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
