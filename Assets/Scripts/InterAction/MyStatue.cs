using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyStatue : MonoBehaviour
{
    [SerializeField]
    private GameObject notice;

    [SerializeField]
    private GameObject statue;


    public void PutStatue()
    {
        if (GameManager.Instance.IsCurCursor("MyStatue"))
        {
            GetComponent<AudioSource>().Play();
            notice.SetActive(true);
            statue.SetActive(true);
        }
    }
}
