using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EyeCamera : SingleTon<EyeCamera>
{
    private int hp = 100;

    [SerializeField]
    private GameObject door;

    public bool horrorOn { get; private set; } = false;

    private Coroutine coroutine;

    private void Start()
    {
        coroutine = StartCoroutine(ChangePos());
    }

    public void Hurt()
    {
        hp -= 100;

        if (hp <= 0)
        {
            //���߼Ҹ�/�뷡�Ҹ� ����

            StopCoroutine(coroutine);
            horrorOn = true;

            door.SetActive(true);
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private IEnumerator ChangePos()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            transform.position = new Vector3(Random.Range(-47,-26), 7f, Random.Range(199, 226));
        }
    }
}
