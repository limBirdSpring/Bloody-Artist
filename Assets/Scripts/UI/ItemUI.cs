using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    private Image itemImage;

    private void Awake()
    {
        itemImage = GetComponent<Image>();
    }

    public void ChangeItemImage()
    {
        itemImage.sprite = ItemManager.Instance.curSetItem.sprite;
    }
}
