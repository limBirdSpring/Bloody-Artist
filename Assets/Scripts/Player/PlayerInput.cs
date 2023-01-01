using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : SingleTon<PlayerInput> // 커서로 조종하는 조사모드와 시야모드 변경, 아이템 장착해제
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

    public bool isTalking;

    public AudioSource audio { get; set; }

    [SerializeField]
    private AudioClip loadScreenSFX;

    [SerializeField]
    private AudioClip NextSFX;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }


    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //대화모드
        if (isTalking)
        {
            Cursor.lockState = CursorLockMode.None; //커서 락 해제
            Cursor.visible = true;
            if (Input.GetMouseButtonDown(0))
            {
                TalkManager.Instance.Talk();
            }
            return;
        }


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
        if (Input.GetButtonDown("UsedKnife") && InvenCanvas.gameObject.activeSelf == false)
        {
            if (ItemManager.Instance.FindItem("Knife"))
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
        audio.clip = NextSFX;
        audio.Play();
        ItemManager.Instance.SetItem(0);
    }

    private void CallInventory()
    {
        if (InvenCanvas.gameObject.activeSelf == false)
        {
            InvenCanvas.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None; //커서 락 해제
            Cursor.visible = true;
        }
        else
        {
            InvenCanvas.GetComponent<AudioSource>().Play();
            InvenCanvas.GetComponentInChildren<Animator>().SetTrigger("InvenClose");
            StartCoroutine(InvenCoroutine());
        }
    }

    private IEnumerator InvenCoroutine()
    {
        yield return new WaitForSeconds(1f);

        InvenCanvas.gameObject.SetActive(false);
    }

}
