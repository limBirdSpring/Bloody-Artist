using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour // 커서로 조종하는 조사모드와 시야모드 변경, 아이템 장착해제
{
    private float mouseX;
    private float mouseY;
    private float RotationX = 0;

    [SerializeField]
    private float mouseSensitivity;

    [SerializeField]
    private Transform mainCamera;

    [SerializeField]
    private Canvas InvenCanvas;



    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //Alt키 : 조사모드로 변경
        if (Input.GetButton("Research"))
        {
            Cursor.lockState = CursorLockMode.None; //커서 락 해제
            Cursor.visible = true;
            if (Input.GetMouseButtonDown(0))
                ResearchMode();
        }
        else if (!InvenCanvas.gameObject.activeSelf)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            PlayerRotate(); //좌우
            ViewRotate(); //위아래
        }
        //T키 : 아이템 장착해제
        if (Input.GetButtonDown("ItemSetRelease"))
            ItemSetRelease();

        //Esc키 : 설정

        //I키 : 인벤토리
        if (Input.GetButtonDown("Inventory"))
        {
            CallInventory();
        }

        //F1키 : 칼 사용 (칼 사용 시 다른 버튼 누르기 불가)
        if (Input.GetButtonDown("UsedKnife"))
        {
            BloodManager.Instance.UsedKnife();
        }

        //Q키 : 누르고 있으면 페인트볼 조준모드로 변경
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

    private void ResearchMode()//조사모드
    {  
        //커서 레이캐스트
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 10))
        {
            //레이캐스트가 조사할 물건에 닿으면 진행해야하는 것
            Debug.DrawRay(ray.origin, ray.direction*10, new Color(255,1,1,1), 1);
            Debug.Log(hit.collider.gameObject.name);

            InterActionAdapter inter = hit.collider.gameObject.GetComponent<InterActionAdapter>();
            inter?.Interaction();
        }
    }

    private void ItemSetRelease()//아이템 장착 해제
    {
        ItemManager.Instance.SetItem(0);
    }

    private void CallInventory()
    {
        InvenCanvas.gameObject.SetActive(!InvenCanvas.gameObject.activeSelf);
        Cursor.lockState = CursorLockMode.None; //커서 락 해제
        Cursor.visible = true;
    }


}
