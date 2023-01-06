using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskTakable : MonoBehaviour
{
    [SerializeField]
    private string answerMask;

    [SerializeField]
    private GameObject mask;

    public void MaskTake()
    {
        if (GameManager.Instance.IsCurCursor(answerMask))
        {
            ItemManager.Instance.UsedItem(answerMask);
            GetComponent<AudioSource>().Play();

            mask.SetActive(true);

            MaskManager.Instance.Collection();

        }
        else if (!GameManager.Instance.IsCurCursor("Research"))
        {
            BloodManager.Instance.Hurt(5);
        }
    }
}
