using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackRoomPointLight : MonoBehaviour
{
    [SerializeField]
    private GameObject player;


    private void Update()
    {
        transform.position = player.transform.position;
    }
}
