using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InvenItemImage : MonoBehaviour
{
    [SerializeField]
    private int invenNum;

    [SerializeField]
    private TextMeshProUGUI num;

    private Image itemImgWindow;

    private void Awake()
    {
        itemImgWindow = GetComponent<Image>();
    }

    private void OnEnable()
    {
        GetComponent<Image>().enabled = false;
        itemImgWindow.color = Color.white;
        itemImgWindow.sprite = null;

        num.text = "";
        if (ItemManager.Instance.inventoryItems.Count > invenNum)
        {
            if (ItemManager.Instance.inventoryItems[invenNum].num >1)
            {
                num.text = ItemManager.Instance.inventoryItems[invenNum].num.ToString();
            }
            GetComponent<Image>().enabled = true;
            itemImgWindow.sprite = ItemManager.Instance.inventoryItems[invenNum].sprite;
        }
        
    }
}
