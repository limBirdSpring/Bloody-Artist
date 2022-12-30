using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkableToPlayer : MonoBehaviour
{
    public void DrinkItem()
    {
        Debug.Log(ItemManager.Instance.curSetItem.fileName);

        BloodManager.Instance.Hurt(10);

        if (GameManager.Instance.IsCurCursor("FePill"))//커서가 철분제일때
        {
            Debug.Log("철분제");
            ItemManager.Instance.UsedItem("FePill");
            BloodManager.Instance.SubTired(30);
        }
    }
}
