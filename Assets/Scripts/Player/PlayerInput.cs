using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour // Ŀ���� �����ϴ� ������� �þ߸�� ����, ������ ��������
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
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //AltŰ : ������� ����
        if (Input.GetButton("Research"))
        {
            Cursor.lockState = CursorLockMode.None; //Ŀ�� �� ����
            Cursor.visible = true;
            ResearchMode();
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            PlayerRotate(); //�¿�
            ViewRotate(); //���Ʒ�
        }

        //TŰ : ������ ��������
        if (Input.GetButtonDown("ItemSetRelease"))
            ItemSetRelease();

        //EscŰ : ����

        //IŰ : �κ��丮

        //F1Ű : Į ��� (Į ��� �� �ٸ� ��ư ������ �Ұ�)

        //QŰ : ������ ������ ����Ʈ�� ���ظ��� ����
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

    private void ResearchMode()//������
    {  
        //Ŀ�� ����ĳ��Ʈ
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 3))
        {
            //����ĳ��Ʈ�� ������ ���ǿ� ������ �����ؾ��ϴ� ��
            Debug.DrawRay(ray.origin, ray.direction, new Color(255,0,0,1), 3);
        }
    }

    private void ItemSetRelease()//������ ���� ����
    {
        ItemManager.instance.SetItem("����");
    }

}
