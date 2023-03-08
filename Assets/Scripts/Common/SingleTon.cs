using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SingleTon<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance;
    public static T Instance
    {
        get
        {
            if (null == instance)
            {
                GameObject gameObject = GameObject.FindObjectOfType<T>().gameObject;
                if (null == gameObject)
                {
                    gameObject = new GameObject();
                    gameObject.AddComponent<T>();
                }
                instance = gameObject.GetOrAddComponent<T>();

                //DontDestroyOnLoad(gameObject);  // ���� ����Ǿ ���ŵ��� �ʴ� ���ӿ�����Ʈ�� ����
            }
            return instance;
        }
    }
}