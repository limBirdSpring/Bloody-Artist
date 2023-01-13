using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeGetable : MonoBehaviour
{
    [SerializeField]
    private GameObject fePill;

    [SerializeField]
    private Transform fePos;

    public void GetFe()
    {
        if (GameManager.Instance.IsCurCursor("RedGem"))
        {
            if (ItemManager.Instance.FindItemNum("RedGem") >= 5)
            {
                GetComponent<AudioSource>().Play();

                for(int i=0;i<5;i++)
                    ItemManager.Instance.UsedItem("RedGem");

                StartCoroutine(Get());
            }
            else
            {
                TalkManager.Instance.researchText = "보석이 부족하다.";
                TalkManager.Instance.ShowResearchText();
            }
        }
    }

    private IEnumerator Get()
    {
        yield return new WaitForSeconds(2f);
        GameObject obj = Instantiate(fePill, fePos.position, Quaternion.identity);
        obj.name = "FePill";
    }
}
