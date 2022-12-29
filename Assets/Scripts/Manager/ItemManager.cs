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
    public Texture2D image;
    public Sprite sprite;
    public string description;
    public int num;
}


public class ItemManager : SingleTon<ItemManager>
{
    //������ ���� �� �κ��丮 ���� ������ ����
    [SerializeField]
    private List<ItemInfo> items = new List<ItemInfo>(); 

    private List<ItemInfo> inventoryItems = new List<ItemInfo>();

    [SerializeField]
    private Image curSetitemImage;//���� ���� ������ �̹���


    public ItemInfo curSetItem; //���� ���� ������

    private void Start()
    {
        curSetItem = items[0];//�� ������
        inventoryItems.Add(items[0]);//����� �⺻ ����
    }

    public void GetItem(string name)//������ ȹ��
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].name == name)//�̹� ������ �ִ� �������̶�� ��������
            {
                ItemInfo item = inventoryItems[i];
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
                ItemInfo item = inventoryItems[i];
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

    public void SetItem(int num)//�κ��丮���� ������ ������ ����
    {
        Debug.Log("����������");
        if (inventoryItems[num].name !=null)
        {
            curSetItem = inventoryItems[num];
            GameManager.instance.CursorChange(inventoryItems[num].image);
            curSetitemImage.sprite = ItemManager.Instance.curSetItem.sprite;
        }
    }

    public void UsedCurSetItem()//���� ������ ������ ���
    {
        UsedItem(curSetItem.name);
    }
}
