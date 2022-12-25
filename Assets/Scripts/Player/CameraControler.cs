using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    private float xRotate, yRotate, xRotateMove, yRotateMove;

    public float rotateSpeed = 500.0f;

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(0)) // Ŭ���� ���
        {
            xRotateMove = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;
            yRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;

            yRotate = transform.eulerAngles.y + yRotateMove;
            //xRotate = transform.eulerAngles.x + xRotateMove; 
            xRotate = xRotate + xRotateMove;

            xRotate = Mathf.Clamp(xRotate, -90, 90); // ��, �Ʒ� ����

            transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
        }
    }
}
