using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Material met;

    private void Update()
    {
        transform.LookAt(player.transform);


        if(EyeCamera.Instance.horrorOn)
        {
            ChangeMesh();
        }
    }

    private void ChangeMesh()
    {
        GetComponent<MeshRenderer>().material = met;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (EyeCamera.Instance.horrorOn)
            BloodManager.Instance.Hurt(5);
    }
}
