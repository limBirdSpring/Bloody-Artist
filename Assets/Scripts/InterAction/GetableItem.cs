using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetableItem : MonoBehaviour
{
    public void GetItem()
    {
        ItemManager.Instance.GetItem(gameObject.name);
        Destroy(gameObject);
    }
}
