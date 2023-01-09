using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackRoonDoor : MonoBehaviour
{
    [SerializeField]
    private Transform playerEndPos;

    [SerializeField]
    private GameObject light;

    private void OnTriggerEnter(Collider other)
    {

        light.SetActive(false);
        other.transform.position = playerEndPos.position;
        Debug.Log("순간이동");
    }
}
