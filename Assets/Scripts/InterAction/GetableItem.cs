using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GetableItem : MonoBehaviour
{
    public UnityEvent OnInterAction;//�������� ���� ��� ������� �̺�Ʈ�� ������ �߰�

    public void GetItem()
    {
        if (GameManager.Instance.IsCurCursor("Research"))//Ŀ���� �����϶�
        {
            ItemManager.Instance.GetItem(gameObject.name);
            Destroy(gameObject);

            OnInterAction?.Invoke();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().Play();
    }
}
