using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetableItem : MonoBehaviour
{
    public void GetItem()
    {
        if (GameManager.Instance.IsCurCursor("����"))//Ŀ���� �����϶�
        {
            ItemManager.Instance.GetItem(gameObject.name);
            Destroy(gameObject);
        }
    }
}
