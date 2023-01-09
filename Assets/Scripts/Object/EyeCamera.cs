using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeCamera : MonoBehaviour
{
    private int hp = 100;

    private void Start()
    {
        StartCoroutine(ChangePos());
    }

    public void Hurt()
    {
        hp -= 10;

        if (hp <= 0)
            Destroy(gameObject);
    }

    private IEnumerator ChangePos()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            transform.position = new Vector3(Random.Range(-47,-26), 7f, Random.Range(59, 200));
        }
    }
}
