using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeGetable : MonoBehaviour
{
    [SerializeField]
    private GameObject fePill;

    public void GetFe()
    {
        if (GameManager.Instance.IsCurCursor("RedGem"))
        {
            if (ItemManager.Instance.FindItemNum("RedGem") >= 5)
            {
                GetComponent<AudioSource>().Play();

                for(int i=0;i<5;i++)
                    ItemManager.Instance.UsedItem("RedGem");

                Instantiate(fePill, GetComponentInChildren<Transform>().position, GetComponentInChildren<Transform>().rotation);
            }
            else
            {
                TalkManager.Instance.researchText = "보석이 부족하다.";
                TalkManager.Instance.ShowResearchText();
            }
        }
    }
}
