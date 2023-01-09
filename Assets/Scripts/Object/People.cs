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
            transform.position -= player.transform.forward * 0.2f * Time.deltaTime;

            ChangeMesh();
        }
    }

    private void ChangeMesh()
    {
        GetComponent<MeshRenderer>().material = met;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player" && EyeCamera.Instance.horrorOn)
            BloodManager.Instance.Hurt(5);
    }
}
