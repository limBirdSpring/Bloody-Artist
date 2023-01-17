using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


[Serializable]
public class ObjectPool : MonoBehaviour
{
    public string objName;

    public GameObject objPrefab;

    private Queue<GameObject> objPrefabList = new Queue<GameObject>();


    private void Awake()
    {
        Init(5);
    }


    private void Init(int count)
    {
        for(int i = 0; i < count; i++)
        {
            objPrefabList.Enqueue(CreateNewObj());
        }
     
    }

    private GameObject CreateNewObj()
    {
        GameObject newObj = Instantiate(objPrefab, transform);
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        newObj.name = objName;
        return newObj;
    }

    public GameObject GetObject()
    {
        if (objPrefabList.Count > 0)
        {
            GameObject obj = objPrefabList.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            GameObject newObj = CreateNewObj();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public void ReturnObject(GameObject obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(transform);
        objPrefabList.Enqueue(obj);
    }
}
