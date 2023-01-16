using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using static UnityEditor.Progress;


//����! ������ ��� List ���� �������� �ʱ�

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


public class ItemManager : SingleTon<ItemManager>, ISavable
{
    //������ ���� �� �κ��丮 ���� ������ ����
    [SerializeField]
    private List<ItemInfo> items =  new List<ItemInfo>();

    public List<ItemInfo> inventoryItems;

    [SerializeField]
    private Image curSetitemImage;//���� ���� ������ �̹���

   
    public ItemInfo curSetItem { get; private set; } //���� ���� ������


    public void OnSave()
    {
        DataManager.Instance.data += JsonUtility.ToJson(inventoryItems);
    }

    private void Awake()
    {
        
        inventoryItems = new List<ItemInfo>();
    }

    private void Start()
    {
        curSetItem = items[0];//�� ������
        inventoryItems.Add(items[0]);//����� �⺻ ����

        //���� �׽�Ʈ�� ������ ���
        GetItem("Knife");
        GetItem("MyStatue");
        GetItem("PaintBallGun");
        GetItem("PaintRoller");
        GetItem("LightKey");
        GetItem("Red");
        GetItem("Red");
        GetItem("Blue");
        GetItem("Blue");
        GetItem("Green");
        GetItem("Green");
        GetItem("Black");
        GetItem("Black");
        GetItem("CardKey");
        GetItem("Photo");
        GetItem("BlackGem");
        //-----------------------
    }

    public void GetItem(string fileName)//������ ȹ��
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {

            if (inventoryItems[i].fileName == fileName)//�̹� ������ �ִ� �������̶�� ��������
            {
                SoundManager.Instance.UIAudioPlay(UISound.GetItem);
                ItemInfo item = inventoryItems[i];
                item.num++;
                inventoryItems[i] = item;
                TalkManager.Instance.RenderGetItemText(inventoryItems[i]);
                return;
            }
        }

        for (int i = 0; i < items.Count; i++)//�ƴ϶�� ���� ������ �߰�
        {

            if (items[i].fileName == fileName)
            {
                SoundManager.Instance.UIAudioPlay(UISound.GetItem);
                inventoryItems.Add(items[i]);
                TalkManager.Instance.RenderGetItemText(items[i]);
                return;
            }
        }
    }

    public void UsedItem(string fileName)//������ ���
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].fileName == fileName)
            {
                ItemInfo item = inventoryItems[i];
                item.num--;
                inventoryItems[i] = item;

                if (inventoryItems[i].num == 0)//������ 0����� �κ��丮���� ����
                {
                    inventoryItems.RemoveAt(i);
                    SetItem(0);
                }

                return;
            }
        }
    }

    public void UsedItem(string fileName, int num)//������ ���
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].fileName == fileName)
            {
                ItemInfo item = inventoryItems[i];
                item.num-=num;
                inventoryItems[i] = item;

                if (inventoryItems[i].num == 0)//������ 0����� �κ��丮���� ����
                {
                    inventoryItems.RemoveAt(i);
                    SetItem(0);
                }

                return;
            }
        }
    }

    public bool FindItem(string fileName)//�ش� �������� �κ��丮�� �ִ��� Ȯ��
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

    public int FindItemNum(string fileName)//�ش� �������� �κ��丮�� �� �� �ִ��� Ȯ��
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].fileName == fileName)
            {
                return inventoryItems[i].num;
            }
        }
        return 0;
    }

    public void SetItem(int num)//�κ��丮���� ������ ������ ����
    {
        Debug.Log("����������");
        if (inventoryItems.Count >num)
        {
            curSetItem = inventoryItems[num];
            GameManager.Instance.CursorChange(inventoryItems[num].image);
            curSetitemImage.sprite = ItemManager.Instance.curSetItem.sprite;
        }
    }

    public void SetItem(string fileName)//�κ��丮���� ������ ������ ����
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].fileName == fileName)
            {
                curSetItem = inventoryItems[i];
                GameManager.Instance.CursorChange(inventoryItems[i].image);
                curSetitemImage.sprite = ItemManager.Instance.curSetItem.sprite;
            }
        }
        
    }

    public void UsedCurSetItem()//���� ������ ������ ���
    {
        UsedItem(curSetItem.fileName);
    }
}
