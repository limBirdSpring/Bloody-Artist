using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> footStep;
    public float repeatTime { get; set; }

    private AudioSource footAudio;

    private void Awake()
    {
        repeatTime = 1f;
        footAudio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        StartCoroutine(StepCoroutine());
    }

    private IEnumerator StepCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(repeatTime);
            int i = Random.Range(0, footStep.Count);
            footAudio.clip = footStep[i];
            footAudio.Play();
        }
    }

    private void OnDisable()
    {
        StopCoroutine(StepCoroutine());
    }
}
