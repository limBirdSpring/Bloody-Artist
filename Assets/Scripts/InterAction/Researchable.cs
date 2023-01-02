using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Researchable : MonoBehaviour
{

    [SerializeField]
    private string text;

    public void Research()
    {
        TalkManager.Instance.ResearchText(text);
    }
}
