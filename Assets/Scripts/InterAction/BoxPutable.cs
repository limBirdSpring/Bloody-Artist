using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPutable : MonoBehaviour
{
    [SerializeField]
    private GameObject box;


    public void PutBox()
    {
        if (GameManager.Instance.IsCurCursor("Box"))
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //���콺 Ŭ���� ��ġ���� �����ǰ� ����
            GameObject obj = Instantiate(box, new Vector3(worldPos.x, worldPos.y, transform.position.z), Quaternion.identity);
            obj.name = "Box";
            ItemManager.Instance.UsedItem("Box");
        }
    }
}
