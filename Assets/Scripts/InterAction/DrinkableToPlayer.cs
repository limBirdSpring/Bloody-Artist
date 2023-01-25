using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkableToPlayer : MonoBehaviour
{
    public void DrinkItem()
    {
        if (GameManager.Instance.IsCurCursor("Research"))
        {
            TalkManager.Instance.researchText = "왼쪽이 상처율, 오른쪽이 피로도. 상처율 100%가 되면 죽는다. 그리고 피로도가 쌓이면 시야가 뿌얘지니 철분제로 관리해줘야지.";
            TalkManager.Instance.ShowResearchText();
        }
        else if (GameManager.Instance.IsCurCursor("FePill"))//커서가 철분제일때
        {
            gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("철분제");
            ItemManager.Instance.UsedItem("FePill");
            BloodManager.Instance.SubTired(30);

            TalkManager.Instance.EraseQuestText();
        }
        else if (GameManager.Instance.IsCurCursor("Coffee"))//커서가 커피일때
        {
            gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("커피");
            ItemManager.Instance.UsedItem("Coffee");
            BloodManager.Instance.SubTired(10);
            StartCoroutine(AddExpCoroutine());
            
        }





    }

    private IEnumerator AddExpCoroutine()
    {
        yield return new WaitForSeconds(2f);
        ExpManager.Instance.AddExp("Pink");
    }
}
