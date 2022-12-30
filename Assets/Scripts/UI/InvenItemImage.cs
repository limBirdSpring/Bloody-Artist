using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenItemImage : MonoBehaviour
{
    [SerializeField]
    private int invenNum;

    private Image itemImgWindow;

    private void Awake()
    {
        itemImgWindow = GetComponent<Image>();
    }

    private void OnEnable()
    {
        if (ItemManager.Instance.inventoryItems.Count >invenNum)
            itemImgWindow.sprite = ItemManager.Instance.inventoryItems[invenNum].sprite;
    }
}
