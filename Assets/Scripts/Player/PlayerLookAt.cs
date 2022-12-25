using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAt : MonoBehaviour
{
    private float mouseX;
    private float mouseY;
    private float RotationX = 0;

    [SerializeField]
    private float mouseSensitivity;

    [SerializeField]
    private Transform mainCamera;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        PlayerRotate(); //ÁÂ¿ì
        ViewRotate(); //À§¾Æ·¡
    }


    private void PlayerRotate()
    { 
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector2.up * mouseX, Space.World);
    
    }

    private void ViewRotate()
    {
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        RotationX -= mouseY;
        RotationX = Mathf.Clamp(RotationX, -90, 90);
        mainCamera.localRotation = Quaternion.Euler(RotationX, 0f, 0f);
    }

}
