using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemGivable : MonoBehaviour
{
    [SerializeField]
    private string gemFileName = "";

    [SerializeField]
    private string gemFileName2 = "";

    [SerializeField]
    private Dialogue dLog;

    private int index;

    public void GiveGem()
    {
        if (gemFileName!="" && GameManager.Instance.IsCurCursor(gemFileName))
        {
            ItemManager.Instance.UsedItem(gemFileName);
            gemFileName = "";

        }
        else if (gemFileName != "" && GameManager.Instance.IsCurCursor(gemFileName2))
        {
            ItemManager.Instance.UsedItem(gemFileName2);
            gemFileName = "";
        }
        else if (gemFileName == "" && gemFileName2 == "")
        {
            //대화하기
        }
        else if (!GameManager.Instance.IsCurCursor("Research"))
        {
            BloodManager.Instance.Hurt(10);
        }
    }
}
