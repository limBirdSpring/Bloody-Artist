using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkableToPlayer : MonoBehaviour
{
    public void DrinkItem()
    {
        if (GameManager.Instance.IsCurCursor("Research"))
        {
            TalkManager.Instance.researchText = "������ ��ó��, �������� �Ƿε�. ��ó�� 100%�� �Ǹ� �״´�. �׸��� �Ƿε��� ���̸� �þ߰� �Ѿ����� ö������ �����������.";
            TalkManager.Instance.ShowResearchText();
        }
        else if (GameManager.Instance.IsCurCursor("FePill"))//Ŀ���� ö�����϶�
        {
            gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("ö����");
            ItemManager.Instance.UsedItem("FePill");
            BloodManager.Instance.SubTired(30);

            TalkManager.Instance.EraseQuestText();
        }
        else if (GameManager.Instance.IsCurCursor("Coffee"))//Ŀ���� Ŀ���϶�
        {
            gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("Ŀ��");
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
