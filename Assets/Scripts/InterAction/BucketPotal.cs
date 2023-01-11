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

    [SerializeField]
    private GameObject eyeCam;

    public void Potal()
    {
        if (GameManager.Instance.IsCurCursor("Research"))
        {
            // ToDo : 믈끼얹는 소리 넣기

            // 양동이 애니메이션 넣기


            blackWaterColor.gameObject.SetActive(true);
            StartCoroutine(SetPlayerPos());
        }
    }

    private IEnumerator SetPlayerPos()
    {
        yield return new WaitForSeconds(3f);
        blackRoom.SetActive(true);
        eyeCam.SetActive(true);
        player.transform.position = potal.position;
        yield return new WaitForSeconds(5f);
        blackWaterColor.gameObject.SetActive(false);

    }
}
