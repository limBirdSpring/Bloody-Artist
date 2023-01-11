using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MeshChangable : MonoBehaviour
{

    [SerializeField]
    private Material material;

    [SerializeField]
    private Light light;

    [SerializeField]
    private StatueControler statue1;

    [SerializeField]
    private StatueControler statue2;
    [SerializeField]
    private StatueControler statue3;
    [SerializeField]
    private StatueControler statue4;


    private MeshRenderer mesh;

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    public void ChangeMesh()
    {
        if (GameManager.Instance.IsCurCursor("Photo"))
        {
            ItemManager.Instance.UsedItem("Photo");
            GetComponent<AudioSource>().Play();
            mesh.material = material;

            //술래잡기 On
            StartCoroutine(LightCoroutine());
        }
    }

    private IEnumerator LightCoroutine()
    {
        SoundManager.Instance.SetBgm(BGMSound.None);
        yield return new WaitForSeconds(1f);
        light.GetComponent<AudioSource>().Play();
        light.intensity = 0.1f;
        
        yield return new WaitForSeconds(0.5f);
        light.intensity = 3f;
        
        yield return new WaitForSeconds(0.5f);

        light.GetComponent<AudioSource>().Play();
        light.intensity = 0f;

        yield return new WaitForSeconds(2f);

        GameManager.Instance.StartRunMode();
        statue1.isMove = true;

        yield return new WaitForSeconds(1f);
        statue2.isMove = true;

        yield return new WaitForSeconds(1f);
        statue3.isMove = true;

        yield return new WaitForSeconds(1f);
        statue4.isMove = true;
    }
}
