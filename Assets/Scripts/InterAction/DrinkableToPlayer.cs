using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkableToPlayer : MonoBehaviour
{
    public void DrinkItem()
    {
        Debug.Log(ItemManager.Instance.curSetItem.fileName);

        //BloodManager.Instance.Hurt(10);

        if (GameManager.Instance.IsCurCursor("FePill"))//Ŀ���� ö�����϶�
        {
            gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("ö����");
            ItemManager.Instance.UsedItem("FePill");
            BloodManager.Instance.SubTired(30);
        }

        if (GameManager.Instance.IsCurCursor("Coffee"))//Ŀ���� Ŀ���϶�
        {
            gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("Ŀ��");
            ItemManager.Instance.UsedItem("Coffee");
            StartCoroutine(AddExpCoroutine());
            
        }
    }

    private IEnumerator AddExpCoroutine()
    {
        yield return new WaitForSeconds(2f);
        ExpManager.Instance.AddExp("Pink");
    }
}
