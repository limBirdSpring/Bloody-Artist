using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkableToPlayer : MonoBehaviour
{
    public void DrinkItem()
    {
        Debug.Log(ItemManager.Instance.curSetItem.fileName);

        BloodManager.Instance.Hurt(10);

        if (GameManager.Instance.IsCurCursor("FePill"))//Ŀ���� ö�����϶�
        {
            Debug.Log("ö����");
            ItemManager.Instance.UsedItem("FePill");
            BloodManager.Instance.SubTired(30);
        }
    }
}
