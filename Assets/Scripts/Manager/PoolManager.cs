using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PoolManager : SingleTon<PoolManager>
{
    [SerializeField]
    private List<ObjectPool> pools = new List<ObjectPool>();

    public void InitObjectFromPool(string name, Vector3 pos, Quaternion rotate)
    {
        for(int i=0; i<pools.Count;i++)
        {
            if (pools[i].objName == name)
            {
                GameObject obj = pools[i].GetObject();

                obj.transform.position = pos;
                obj.transform.rotation = rotate;

            }
        }
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        for (int i = 0; i < pools.Count; i++)
        {
            if (pools[i].objName == obj.name)
            {
                pools[i].ReturnObject(obj);
             
            }
        }
    }
}
