using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("IsOpen", false);
        Destroy(gameObject);
    }
}
