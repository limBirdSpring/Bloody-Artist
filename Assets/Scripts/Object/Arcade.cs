using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arcade : MonoBehaviour
{

    [SerializeField]
    private Material ghost;

    [SerializeField]
    private Material normal;

    private AudioSource audio;

    [SerializeField]
    private float coolTime;

    private MeshRenderer meshRenderer;


    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void AppearGhost()
    {
        StartCoroutine(AppearCoroutine());
    }

    private IEnumerator AppearCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            meshRenderer.material = ghost;
            audio.Play();

            yield return new WaitForSeconds(coolTime);
            meshRenderer.material = normal;
            audio.Stop();
        }
    }
}
