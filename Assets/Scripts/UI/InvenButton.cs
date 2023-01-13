using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenButton : MonoBehaviour
{
    [SerializeField]
    private GameObject itemPanel1;

    [SerializeField]
    private GameObject itemPanel2;

    public void SetItemPanel()
    {
        SoundManager.Instance.UIAudioPlay(UISound.Next);
        itemPanel1.SetActive(!itemPanel1.activeSelf);
        itemPanel2.SetActive(!itemPanel2.activeSelf);
    }
}
