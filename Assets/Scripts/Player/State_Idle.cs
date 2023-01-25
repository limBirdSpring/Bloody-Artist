using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class State_Idle : State
{
    //LookAt

    private float mouseX;
    private float mouseY;
    private float RotationX = 0;

    [SerializeField]
    private float mouseSensitivity;

    [SerializeField]
    private Transform mainCamera;

    //Move

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



    public override void Action()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PlayerRotate(); //좌우
        ViewRotate(); //위아래

        Move();
        Gravity();

        if (Input.GetButton("PaintBall"))//페인트볼
        {
            if (ItemManager.Instance.FindItem("PaintBallGun"))
            {
                footStep.gameObject.SetActive(false);
                InputManager.Instance.ChangeState(StateName.PaintBall);
            }
        }
        if (Input.GetButton("Research"))//조사
        {
            footStep.gameObject.SetActive(false);
            InputManager.Instance.ChangeState(StateName.Research);
        }

        if (Input.GetButtonDown("ItemSetRelease"))//아이템 장착해제
        {
            SoundManager.Instance.UIAudioPlay(UISound.Next);
            ItemManager.Instance.SetItem(0);
        }

        if (GameManager.Instance.isRunMode)
        {
            return;
        }

        if (Input.GetButtonDown("Inventory"))//인벤토리
        {
            footStep.gameObject.SetActive(false);
            InputManager.Instance.ChangeState(StateName.Inventory);
        }

        if (Input.GetButtonDown("Cancel"))//설정
        {
            SoundManager.Instance.UIAudioPlay(UISound.ScreenOn);
            footStep.gameObject.SetActive(false);
            InputManager.Instance.ChangeState(StateName.Setting);
        }

        if (Input.GetButtonDown("UsedKnife"))//칼 사용
        {
            if (ItemManager.Instance.FindItem("Knife"))

                BloodManager.Instance.UsedKnife();
            
        }

        //치트키
        if (Input.GetKeyDown(KeyCode.F5))
        {
            ItemManager.Instance.GetItem("FePill");
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            if(BloodManager.Instance.hurtPercent >= 30)
                 BloodManager.Instance.Heal(10);
        }

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





    private void Move()
    {
        charCon.Move(transform.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime);

        charCon.Move(transform.forward * Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);

        if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
        {
            footStep.repeatTime = 0.9f - moveSpeed * 0.1f;
            footStep.gameObject.SetActive(true);
        }
        else
        {
            footStep.gameObject.SetActive(false);
        }
    }

    private void Gravity()
    {
        if (!charCon.isGrounded)
        {
            charCon.Move(Vector3.up * gravity * Time.deltaTime);
        }
    }

}
