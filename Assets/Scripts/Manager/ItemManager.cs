using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public struct ItemInfo
{
    public string name;
    public string fileName;
    public Texture2D image;
    public Sprite sprite;
    public string description;
    public int num;
}


public class ItemManager : SingleTon<ItemManager>
{
    //아이템 종류 및 인벤토리 소지 아이템 관리
    [SerializeField]
    private List<ItemInfo> items =  new List<ItemInfo>();

    public List<ItemInfo> inventoryItems;

    [SerializeField]
    private Image curSetitemImage;//현재 장착 아이템 이미지

    public ItemInfo curSetItem { get; private set; } //현재 장착 아이템

    private void Awake()
    {
        
        inventoryItems = new List<ItemInfo>();
    }

    private void Start()
    {
        curSetItem = items[0];//빈 아이템
        inventoryItems.Add(items[0]);//조사는 기본 장착
    }

    public void GetItem(string fileName)//아이템 획득
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {

            if (inventoryItems[i].fileName == fileName)//이미 가지고 있는 아이템이라면 개수변경
            {
                ItemInfo item = inventoryItems[i];
                item.num++;
                inventoryItems[i] = item;
                return;
            }
        }

        for (int i = 0; i < items.Count; i++)//아니라면 새로 아이템 추가
        {

            if (items[i].fileName == fileName)
            {
                inventoryItems.Add(items[i]);
                return;
            }
        }
    }

    public void UsedItem(string fileName)//아이템 사용
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].fileName == fileName)
            {
                ItemInfo item = inventoryItems[i];
                item.num--;
                inventoryItems[i] = item;

                if (inventoryItems[i].num == 0)//개수가 0개라면 인벤토리에서 지움
                {
                    inventoryItems.RemoveAt(i);
                    SetItem(0);
                }

                return;
            }
        }
    }

    public bool FindItem(string fileName)//해당 아이템이 인벤토리에 있는지 확인
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].fileName == fileName)
            {
                return true;
            }
        }
        return false;
    }

    public void SetItem(int num)//인벤토리에서 선택한 아이템 장착
    {
        Debug.Log("아이템장착");
        if (inventoryItems.Count >num)
        {
            curSetItem = inventoryItems[num];
            GameManager.instance.CursorChange(inventoryItems[num].image);
            curSetitemImage.sprite = ItemManager.Instance.curSetItem.sprite;
        }
    }

    public void UsedCurSetItem()//현재 장착한 아이템 사용
    {
        UsedItem(curSetItem.fileName);
    }
}
