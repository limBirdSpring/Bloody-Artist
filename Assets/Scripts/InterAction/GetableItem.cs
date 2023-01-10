using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GetableItem : MonoBehaviour
{
    public UnityEvent OnInterAction;//아이템을 먹은 경우 해줘야할 이벤트가 있으면 추가

    public void GetItem()
    {
        if (GameManager.Instance.IsCurCursor("Research"))//커서가 조사일때
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
