using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshChangable : MonoBehaviour
{

    [SerializeField]
    private Material material;


    private MeshRenderer mesh;

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    public void ChangeMesh()
    {
        if (GameManager.Instance.IsCurCursor("Photo"))
        {
            GetComponent<AudioSource>().Play();
            mesh.material = material;

            //술래잡기 On
        }
    }
}
