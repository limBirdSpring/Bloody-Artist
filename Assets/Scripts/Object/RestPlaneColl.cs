using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestPlaneColl : MonoBehaviour
{
    [SerializeField]
    private Transform pos;

    [SerializeField]
    private GameObject box;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Box")
        {
            Destroy(collision.gameObject);
            Instantiate(box, pos.position, Quaternion.identity);
        }
    }
}
