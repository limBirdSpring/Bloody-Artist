using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawable : MonoBehaviour
{
    private bool isPainting=false;

    private int step=0;

    private MeshRenderer mesh;

    [SerializeField]
    private Material met2;

    [SerializeField]
    private Material met3;

    [SerializeField]
    private Material met4;

    [SerializeField]
    private GameObject statue;

    [SerializeField]
    private CinemachineVirtualCamera cam;


    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    public void Draw()
    {

        if (GameManager.Instance.IsCurCursor("PaintRoller"))
        {
            if (isPainting)
            {
                if (step==1)
                {
                    cam.Priority = 20;
                    GetComponent<AudioSource>().Play();
                    ItemManager.Instance.UsedItem("Black", 2);
                    ItemManager.Instance.UsedItem("Red", 2);
                    ItemManager.Instance.SetItem("PaintRoller");
                    mesh.material = met3;
                    cam.Priority = 1;
                    step++;

                }
                else if (step == 2)
                {
                    cam.Priority = 20;
                    GetComponent<AudioSource>().Play();
                    ItemManager.Instance.UsedItem("Green", 2);
                    ItemManager.Instance.SetItem("PaintRoller");
                    mesh.material = met4;
                    cam.Priority = 1;
                    step++;
                }
                else if(step == 3)
                {
                    cam.Priority = 20;
                    ItemManager.Instance.UsedItem("PaintRoller");

                    //튀어나오기
                    statue.GetComponent<AudioSource>().Play();
                    statue.SetActive(true);
                    statue.GetComponent<Rigidbody>().AddForce(transform.forward * -5, ForceMode.Impulse);
                    StartCoroutine(HorrorCoroutine());
                    step++;
                }
            }
            else
            {
                if (ItemManager.Instance.FindItemNum("Red") == 2 &&
                    ItemManager.Instance.FindItemNum("Blue") == 2 &&
                    ItemManager.Instance.FindItemNum("Black") == 2 &&
                    ItemManager.Instance.FindItemNum("Green") == 2)
                {
                    cam.Priority = 20;
                    GetComponent<AudioSource>().Play();
                    ItemManager.Instance.UsedItem("Blue", 2);
                    ItemManager.Instance.SetItem("PaintRoller");
                    isPainting = true;
                    //그림 메쉬 변형
                    mesh.material = met2;
                    step++;
                    cam.Priority = 1;
                }
                else
                {
                    TalkManager.Instance.researchText = "물감이 부족하다.";
                    TalkManager.Instance.ShowResearchText();
                }
            }
        }

    }

    private IEnumerator HorrorCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        cam.Priority = 1;
        statue.GetComponent<CapsuleCollider>().enabled = true;
    }
}
