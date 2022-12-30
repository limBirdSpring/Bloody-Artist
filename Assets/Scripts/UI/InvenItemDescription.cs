using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InvenItemDescription : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI itemName;
    [SerializeField]
    private TextMeshProUGUI description;

    private void OnEnable()
    {
        itemName.text = "";
        description.text = "";
    }

    public void ChangeItemText(int num)
    {
        itemName.text = ItemManager.Instance.inventoryItems[num].name;
        TalkManager.Instance.TextFlow(description, ItemManager.Instance.inventoryItems[num].description);
    }
}
