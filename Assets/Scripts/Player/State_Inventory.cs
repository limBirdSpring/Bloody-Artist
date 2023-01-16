using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Inventory : State
{
    [SerializeField]
    private Canvas InvenCanvas;

    public override void Action()
    {
        CallInventory();

        if (Input.GetButtonDown("ItemSetRelease"))//������ ��������
        {
            SoundManager.Instance.UIAudioPlay(UISound.Next);
            ItemManager.Instance.SetItem(0);
        }

        if (Input.GetButtonDown("Inventory") || Input.GetButtonDown("Cancel"))//�κ��丮
        {
            ExitInventory();
        }
    }

    private void CallInventory()
    {
        InvenCanvas.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None; //Ŀ�� �� ����
        Cursor.visible = true;
    }

    private void ExitInventory()
    {
        SoundManager.Instance.UIAudioPlay(UISound.Inven);
        InvenCanvas.GetComponentInChildren<Animator>().SetTrigger("InvenClose");
        StartCoroutine(InvenCoroutine());
    }

    private IEnumerator InvenCoroutine()
    {
        yield return new WaitForSeconds(0.6f);

        InvenCanvas.gameObject.SetActive(false);
        InputManager.Instance.ChangeState(StateName.Idle);
    }
}