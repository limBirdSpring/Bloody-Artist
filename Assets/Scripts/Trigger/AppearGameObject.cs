using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearGameObject : MonoBehaviour
{

    [SerializeField]
    GameObject m_gameObject;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            m_gameObject.SetActive(true);
        }
    }
}
