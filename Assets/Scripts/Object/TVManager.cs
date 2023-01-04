using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class TVManager : SingleTon<TVManager>
{
    public List<TVChannelChanger> channelList;

    [SerializeField]
    private GameObject dangerTV;

    [SerializeField]
    private GameObject normalTV;

    [SerializeField]
    private Material idol;

    [SerializeField]
    private Material game;

    [SerializeField]
    private Material art;

    [SerializeField]
    private Material toon;

    [SerializeField]
    private Material error;

    [SerializeField]
    private Animator cavinetAnim;

    private MeshRenderer mash;

    private int curImage = 0;

    private Coroutine coroutine;

    private void Awake()
    {
        mash = GetComponent<MeshRenderer>();    
    }

    private void Start()
    {
        ChangeChannel();
    }

    private void Update()
    {
        CheckChannel();
    }

    private void CheckChannel()
    {
        for (int i = 0; i < channelList.Count - 1; i++)
        {
            if (channelList[i].curChannel != channelList[i + 1].curChannel)
            {
                break;
            }

            if (i == channelList.Count - 1)
            {
                if (curImage == channelList[i].curChannel)
                {
                    //모든 화면 바뀌고 자물쇠 열림
                    OpenCavinet();
                }
            }
        }
    }

    private void OpenCavinet()
    {
        //에러소리 재생

        StopCoroutine(coroutine);

        for(int i=0;i<channelList.Count;i++)
        {
            channelList[i].curChannel = 5;
            
        }

        mash.material = error;

        cavinetAnim.GetComponent<AudioSource>().Play();
        cavinetAnim.SetTrigger("Open");
        
    }

    private void ChangeChannel()
    {
        coroutine = StartCoroutine(Changer());

    }

    private IEnumerator Changer()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);

            if (curImage < 3)
                curImage++;
            else
                curImage = 0;

            Debug.Log(curImage);

            switch (curImage)
            {
                case 0:
                    mash.material = idol;
                    break;
                case 1:
                    mash.material = game;
                    break;
                case 2:
                    mash.material = toon;
                    break;
                case 3:
                    mash.material = art;
                    break;
            }
        }
    }


    public void ChangeTV()
    {
        normalTV.GetComponentInChildren<TVChannelChanger>().curChannel = 3;
        normalTV.SetActive(true);
        dangerTV.SetActive(false);
    }
}
