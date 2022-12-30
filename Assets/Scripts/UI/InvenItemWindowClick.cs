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

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            //������ ���� ���
            Textui.ChangeItemText(num);
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            ItemManager.Instance.SetItem(num);
        }
    }
}
