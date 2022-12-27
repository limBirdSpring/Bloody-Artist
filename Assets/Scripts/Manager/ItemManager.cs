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
    //������ ���� �� �κ��丮 ���� ������ ����
    [SerializeField]
    private List<Item> items = new List<Item>(); 

    private List<Item> inventoryItems = new List<Item>();


    private Item curSetItem; //���� ���� ������
    

    public void GetItem(string name)//������ ȹ��
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].name == name)//�̹� ������ �ִ� �������̶�� ��������
            {
                Item item = inventoryItems[i];
                item.num++;
                inventoryItems[i] = item;
                return;
            }
        }

        for (int i = 0; i < items.Count; i++)//�ƴ϶�� ���� ������ �߰�
        {
            if (items[i].name == name)
            {
                inventoryItems.Add(items[i]);
                return;
            }
        }
    }

    public void UsedItem(string name)//������ ���
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].name == name)
            {
                Item item = inventoryItems[i];
                item.num--;
                inventoryItems[i] = item;

                if (inventoryItems[i].num == 0)//������ 0����� �κ��丮���� ����
                    inventoryItems.RemoveAt(i);

                return;
            }
        }
    }

    public bool FindItem(string name)//�ش� �������� �κ��丮�� �ִ��� Ȯ��
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

    public void SetItem(string name)//�κ��丮���� ������ ������ ����
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].name == name)
            {
                curSetItem = inventoryItems[i];
            }
        }
    }

    public void UsedCurSetItem()//���� ������ ������ ���
    {
        UsedItem(curSetItem.name);
    }
}
