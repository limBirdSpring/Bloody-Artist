using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Inventory : MonoBehaviour, State
{
    [SerializeField]
    private Canvas InvenCanvas;

    public void Action()
    {
        CallInventory();

        if (Input.GetButtonDown("ItemSetRelease"))//아이템 장착해제
        {
            SoundManager.Instance.UIAudioPlay(UISound.Next);
            ItemManager.Instance.SetItem(0);
        }
    }

    private void CallInventory()
    {
        if (Input.GetButtonDown("Inventory"))//인벤토리
        {
            InvenCanvas.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None; //커서 락 해제
            Cursor.visible = true;
        }
        else if (Input.GetButtonDown("Inventory") || Input.GetButtonDown("Escape"))//인벤토리
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
        InputManager.Instance.ChangeState(StateName.Idle);
    }
}