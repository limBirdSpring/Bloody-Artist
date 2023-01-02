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

        if (Input.GetButtonDown("ItemSetRelease"))//������ ��������
        {
            SoundManager.Instance.UIAudioPlay(UISound.Next);
            ItemManager.Instance.SetItem(0);
        }
    }

    private void CallInventory()
    {
        if (Input.GetButtonDown("Inventory"))//�κ��丮
        {
            InvenCanvas.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None; //Ŀ�� �� ����
            Cursor.visible = true;
        }
        else if (Input.GetButtonDown("Inventory") || Input.GetButtonDown("Escape"))//�κ��丮
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