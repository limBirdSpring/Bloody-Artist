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

    [SerializeField]
    private FootStep footStep;


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

        if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
        {
            footStep.repeatTime = 0.9f - moveSpeed*0.1f;
            footStep.gameObject.SetActive(true);
        }
        else
        {
            footStep.gameObject.SetActive(false);
        }
    }

    private void Gravity()
    {
        if(!charCon.isGrounded)
        {
            charCon.Move(Vector3.up * gravity * Time.deltaTime);
        }
    }

}
