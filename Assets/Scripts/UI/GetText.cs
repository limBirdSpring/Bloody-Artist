using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GetText : MonoBehaviour
{
    private TextMeshProUGUI getUI;

    private void Awake()
    {
        getUI = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        getUI.CrossFadeAlpha(0f, 0f, false);
        StartCoroutine(FadeUI());
    }

    private IEnumerator FadeUI()
    {
        getUI.CrossFadeAlpha(1f, 1f, false);

        yield return new WaitForSeconds(2f);
        getUI.CrossFadeAlpha(0f, 0.5f, false);

        yield return new WaitForSeconds(0.5f);
        getUI.gameObject.SetActive(false);

        
    }
}
