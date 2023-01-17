using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBall : MonoBehaviour
{

    private void OnEnable()
    {
        StartCoroutine(Cor());
    }


    private IEnumerator Cor()
    {
        yield return new WaitForSeconds(2f);
        PoolManager.Instance.ReturnObjectToPool(gameObject);
    }

}
