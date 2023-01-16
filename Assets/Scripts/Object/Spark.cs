using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : MonoBehaviour
{
    [SerializeField]
    private float time = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SparkCoroutine());
    }

    private IEnumerator SparkCoroutine()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

   
}
