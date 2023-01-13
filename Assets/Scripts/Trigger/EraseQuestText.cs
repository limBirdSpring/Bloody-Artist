using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseQuestText : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        TalkManager.Instance.EraseQuestText();
    }
}
