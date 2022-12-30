using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetableItem : MonoBehaviour
{
    public void GetItem()
    {
        if (GameManager.Instance.IsCurCursor("조사"))//커서가 조사일때
        {
            ItemManager.Instance.GetItem(gameObject.name);
            Destroy(gameObject);
        }
    }
}
