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
            /*
            //Ŀ�� ����ĳ��Ʈ
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 2))
            {
                //����ĳ��Ʈ�� ������ ���ǿ� ������ �����ؾ��ϴ� ��
                Debug.DrawRay(ray.origin, ray.direction * 10, new Color(255, 1, 1, 1), 1);
                Debug.Log(hit.collider.gameObject.name);

                if (hit.collider == null)
                {
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 2f);

                    //���콺 Ŭ���� ��ġ���� �����ǰ� ����
                    GameObject obj = Instantiate(box, worldPos, Quaternion.identity);
                    obj.name = "Box";
                    ItemManager.Instance.UsedItem("Box");
                }
                else
                {
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * hit.distance);

                    //���콺 Ŭ���� ��ġ���� �����ǰ� ����
                    GameObject obj = Instantiate(box, worldPos, Quaternion.identity);
                    obj.name = "Box";
                    ItemManager.Instance.UsedItem("Box");
                }
            }
            */

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 2f);

            //���콺 Ŭ���� ��ġ���� �����ǰ� ����
            GameObject obj = Instantiate(box, worldPos, Quaternion.identity);
            obj.name = "Box";
            ItemManager.Instance.UsedItem("Box");


        }
    }
}
