using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BucketPotal : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Transform potal;

    [SerializeField]
    private Image blackWaterColor;

    [SerializeField]
    private GameObject blackRoom;

    public void Potal()
    {
        // ToDo : �ɳ���� �Ҹ� �ֱ�

        // �絿�� �ִϸ��̼� �ֱ�


        blackWaterColor.gameObject.SetActive(true);
        StartCoroutine(SetPlayerPos());
    }

    private IEnumerator SetPlayerPos()
    {
        yield return new WaitForSeconds(3f);
        blackRoom.SetActive(true);
        player.transform.position = potal.position;
        yield return new WaitForSeconds(5f);
        blackWaterColor.gameObject.SetActive(false);
    }
}