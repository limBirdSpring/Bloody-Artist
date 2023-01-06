using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuctionManager : SingleTon<AuctionManager>
{
    private AudioSource audio;

    [SerializeField]
    private AudioClip clap;

    [SerializeField]
    private AudioClip price;

    [SerializeField]
    private List<ChangeNoticeToPrice> notice;


    public bool isStartAuction { get; private set; } = false;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    public void StartAuction()
    {
        StartCoroutine(AuctionCoroutine());
    }

    private IEnumerator AuctionCoroutine()
    {
        yield return new WaitForSeconds(2f);
        audio.clip = clap;
        audio.Play();

        yield return new WaitForSeconds(4f);
        audio.clip = price;
        audio.Play();

        //파티클 생성

        //가격표 메쉬로 바꾸기
        for (int i = 0; i < notice.Count; i++)
        {
            notice[i].ChangeMaterial();
        }

        isStartAuction = true;
    }
}
