using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spark : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SparkCoroutine());
    }

    private IEnumerator SparkCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

   
}
