using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InvenItemWindowClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private InvenItemDescription Textui;

    [SerializeField]
    private int num;

    [SerializeField]
    private AudioClip click;

    [SerializeField]
    private AudioClip set;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (ItemManager.Instance.inventoryItems.Count > num)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                gameObject.GetComponent<AudioSource>().clip = click;
                gameObject.GetComponent<AudioSource>().Play();
                //아이템 설명 출력
                Textui.ChangeItemText(num);
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                gameObject.GetComponent<AudioSource>().clip = set;
                gameObject.GetComponent<AudioSource>().Play();
                ItemManager.Instance.SetItem(num);
            }
        }
    }
}
