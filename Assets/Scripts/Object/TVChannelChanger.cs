using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVChannelChanger : MonoBehaviour
{
    public int curChannel =0;

    private MeshRenderer mash;

    [SerializeField]
    public Material idol;

    [SerializeField]
    public Material game;


    [SerializeField]
    public Material toon;

    [SerializeField]
    public Material art;

    [SerializeField]
    public Material error;



    private void Awake()
    {
        
        mash = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (curChannel == 5)
        {
            mash.material = error;
            return;
        }
    }

    public void ChangeChannel()
    {
        //리모콘이 있을 때
        if (GameManager.Instance.IsCurCursor("RemotCon") && curChannel < 4)//커서가 리모콘일때
        {
            GetComponent<AudioSource>().Play();

            if (curChannel < 3)
                curChannel++;
            else
                curChannel = 0;

            Debug.Log(curChannel);

            switch (curChannel)
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
}
