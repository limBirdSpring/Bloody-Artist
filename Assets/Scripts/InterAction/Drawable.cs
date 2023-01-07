using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawable : MonoBehaviour
{
    private bool isPainting=false;

    private int step=0;

    private Coroutine curCoroutine;

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
                if (step==1 && curCoroutine==null)
                {
                    InputManager.Instance.ChangeState(StateName.Research);

                    ItemManager.Instance.UsedItem("Black", 2);
                    ItemManager.Instance.UsedItem("Red", 2);
                    ItemManager.Instance.SetItem("PaintRoller");
                    curCoroutine = StartCoroutine(DrawCoroutine(met3));

                }
                else if (step == 2 && curCoroutine == null)
                {
                    InputManager.Instance.ChangeState(StateName.Research);
     
                    ItemManager.Instance.UsedItem("Green", 2);
                    ItemManager.Instance.SetItem("PaintRoller");
                    curCoroutine = StartCoroutine(DrawCoroutine(met4));
                }
                else if(step == 3 && curCoroutine == null)
                {

                    InputManager.Instance.ChangeState(StateName.Research);
                    //튀어나오기
                    
                    statue.SetActive(true);
                    statue.GetComponent<Rigidbody>().AddForce(transform.forward * -5, ForceMode.Impulse);
                    curCoroutine = StartCoroutine(HorrorCoroutine());
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
                    InputManager.Instance.ChangeState(StateName.BlockResearch);
                    cam.Priority = 20;
                    ItemManager.Instance.UsedItem("Blue", 2);
                    ItemManager.Instance.SetItem("PaintRoller");
                    isPainting = true;
                    //그림 메쉬 변형
                    curCoroutine = StartCoroutine(DrawCoroutine(met2));
                    //cam.Priority = 1;
                }
                else
                {
                    TalkManager.Instance.researchText = "물감이 부족하다.";
                    TalkManager.Instance.ShowResearchText();
                }
            }
        }

    }

    private IEnumerator DrawCoroutine(Material material)
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.2f);
        mesh.material = material;
        step++;
        curCoroutine = null;
    }

    private IEnumerator HorrorCoroutine()
    {
        yield return new WaitForSeconds(0.4f);
        cam.Priority = 1;
        statue.GetComponent<CapsuleCollider>().enabled = true;
        ItemManager.Instance.UsedItem("PaintRoller");
        InputManager.Instance.ChangeState(StateName.Idle);

    }
}
