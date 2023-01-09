using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EyeCamera : MonoBehaviour
{
    private int hp = 100;

    [SerializeField]
    private GameObject door;

    private void Start()
    {
        StartCoroutine(ChangePos());
    }

    public void Hurt()
    {
        hp -= 10;

        if (hp <= 0)
        {
            //사람들 매쉬 변경
            door.SetActive(true);
            Destroy(gameObject);
        }
    }

    private IEnumerator ChangePos()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            transform.position = new Vector3(Random.Range(-47,-26), 7f, Random.Range(160, 200));
        }
    }
}
