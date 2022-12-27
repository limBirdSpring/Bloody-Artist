using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public struct Item
{
    public string name;
    public Image image;
    public string description;
    public int num;
}


public class ItemManager : SingleTon<ItemManager>
{
    //아이템 종류 및 인벤토리 소지 아이템 관리
    [SerializeField]
    private List<Item> items = new List<Item>(); 

    private List<Item> inventoryItems = new List<Item>();


    private Item curSetItem; //현재 장착 아이템
    

    public void GetItem(string name)//아이템 획득
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].name == name)//이미 가지고 있는 아이템이라면 개수변경
            {
                Item item = inventoryItems[i];
                item.num++;
                inventoryItems[i] = item;
                return;
            }
        }

        for (int i = 0; i < items.Count; i++)//아니라면 새로 아이템 추가
        {
            if (items[i].name == name)
            {
                inventoryItems.Add(items[i]);
                return;
            }
        }
    }

    public void UsedItem(string name)//아이템 사용
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].name == name)
            {
                Item item = inventoryItems[i];
                item.num--;
                inventoryItems[i] = item;

                if (inventoryItems[i].num == 0)//개수가 0개라면 인벤토리에서 지움
                    inventoryItems.RemoveAt(i);

                return;
            }
        }
    }

    public bool FindItem(string name)//해당 아이템이 인벤토리에 있는지 확인
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].name == name)
            {
                return true;
            }
        }
        return false;
    }

    public void SetItem(string name)//인벤토리에서 선택한 아이템 장착
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].name == name)
            {
                curSetItem = inventoryItems[i];
            }
        }
    }

    public void UsedCurSetItem()//현재 장착한 아이템 사용
    {
        UsedItem(curSetItem.name);
    }
}
