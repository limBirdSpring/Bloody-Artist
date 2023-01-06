using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeNoticeToPrice : MonoBehaviour
{
    private MeshRenderer mesh;

    [SerializeField]
    private Material material;

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    public void ChangeMaterial()
    {
        mesh.material = material;
    }
}
