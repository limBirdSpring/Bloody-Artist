using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkableToPlayer : MonoBehaviour
{
    public void DrinkItem()
    {
        Debug.Log(ItemManager.Instance.curSetItem.fileName);

        //BloodManager.Instance.Hurt(10);

        if (GameManager.Instance.IsCurCursor("FePill"))//커서가 철분제일때
        {
            gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("철분제");
            ItemManager.Instance.UsedItem("FePill");
            BloodManager.Instance.SubTired(30);
        }

        if (GameManager.Instance.IsCurCursor("Coffee"))//커서가 커피일때
        {
            gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("커피");
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
