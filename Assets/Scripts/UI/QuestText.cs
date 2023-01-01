using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestText : MonoBehaviour
{
    private TextMeshProUGUI questUI;

    private void Awake()
    {
        questUI = GetComponent<TextMeshProUGUI>();  
    }

    private void OnEnable()
    {
        questUI.CrossFadeAlpha(0f, 0f, false);
        StartCoroutine(FadeUI());
    }

    private IEnumerator FadeUI()
    {
        questUI.CrossFadeAlpha(1f, 0.8f, false);

        while (true)
        {
            yield return new WaitForSeconds(1f);
            questUI.CrossFadeAlpha(0f, 0.5f, false);

            yield return new WaitForSeconds(0.3f);
            questUI.CrossFadeAlpha(1f, 0.5f, false);

        }
    }
}
