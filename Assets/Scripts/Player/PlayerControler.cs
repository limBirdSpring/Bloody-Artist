using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private CharacterController charCon;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float gravity;


    private void Awake()
    {
        charCon = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Gravity();
    }

    private void Move()
    {
        charCon.Move(transform.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime);

        charCon.Move(transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
    }

    private void Gravity()
    {
        if(!charCon.isGrounded)
        {
            charCon.Move(Vector3.up * gravity * Time.deltaTime);
        }
    }

}
