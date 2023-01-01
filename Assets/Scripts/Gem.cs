using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(new Vector3(Random.Range(2,5), Random.Range(2, 5), Random.Range(2, 5)), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<AudioSource>().volume = Random.Range(0.6f, 0.8f);
        gameObject.GetComponent<AudioSource>().pitch = Random.Range(0.8f,1.5f);
        gameObject.GetComponent<AudioSource>().Play();
    }
}
