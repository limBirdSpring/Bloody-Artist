using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Researchable : MonoBehaviour
{

    [SerializeField]
    private string text;

    public void Research()
    {

        if(GameManager.Instance.IsCurCursor("Research"))//커서가 조사일때
        {
            TalkManager.Instance.researchText = text;
            TalkManager.Instance.ShowResearchText();
        }    }
}
