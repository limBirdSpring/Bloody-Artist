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

    private int index=0;

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
        else if (!GameManager.Instance.IsCurCursor("Research"))
        {
            BloodManager.Instance.Hurt(10);
        }

        if (gemFileName == "" && gemFileName2 == "")
        {
            GetComponent<Talkable>().enabled = false;

            //대화하기
            if (GameManager.Instance.IsCurCursor("Research"))//커서가 조사일때
            { 
                if (index != 0)
                {
                    if (dLog.dialogue.Count > index && !TalkManager.Instance.isTexting)
                        index++;

                }

                if (dLog.dialogue.Count <= index)
                {
                    Destroy(gameObject);
                }

                TalkManager.Instance.curDlog = dLog;
                TalkManager.Instance.Talk(index);


                if (index == 0)
                    index++;


            }
        }

    }
}
