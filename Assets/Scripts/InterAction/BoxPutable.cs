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
            //커서 레이캐스트
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 2))
            {
                //레이캐스트가 조사할 물건에 닿으면 진행해야하는 것
                Debug.DrawRay(ray.origin, ray.direction * 10, new Color(255, 1, 1, 1), 1);
                Debug.Log(hit.collider.gameObject.name);

                if (hit.collider == null)
                {
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 2f);

                    //마우스 클릭한 위치에서 생성되게 변경
                    GameObject obj = Instantiate(box, worldPos, Quaternion.identity);
                    obj.name = "Box";
                    ItemManager.Instance.UsedItem("Box");
                }
                else
                {
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * hit.distance);

                    //마우스 클릭한 위치에서 생성되게 변경
                    GameObject obj = Instantiate(box, worldPos, Quaternion.identity);
                    obj.name = "Box";
                    ItemManager.Instance.UsedItem("Box");
                }
            }
            */

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 2f);

            //마우스 클릭한 위치에서 생성되게 변경
            GameObject obj = Instantiate(box, worldPos, Quaternion.identity);
            obj.name = "Box";
            ItemManager.Instance.UsedItem("Box");


        }
    }
}
