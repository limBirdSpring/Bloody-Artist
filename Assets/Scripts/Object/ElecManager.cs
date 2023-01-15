using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ElecManager : SingleTon<ElecManager>
{
    [SerializeField]
    private Elecable red;

    [SerializeField]
    private Elecable black;

    [SerializeField]
    private Elecable green;
    
    [SerializeField]
    private Elecable blue;

    private List<Elecable> elecList = new List<Elecable>();

    [SerializeField]
    private GameObject half;

    [SerializeField]
    private GameObject all;

    [SerializeField]
    private ParticleSystem spark;

    private bool isOn;


    public void ElecUpdate(string name)
    {
        switch(name)
        {
            case "Red":
                elecList.Add(red);
                break;
            case "Black":
                elecList.Add(black);
                break;
            case "Green":
                elecList.Add(green);
                break;
            case "Blue":
                elecList.Add(blue);
                break;
        }

         
    }

    public void Cut()
    {
        if (GameManager.Instance.IsCurCursor("Knife") && !isOn)
        {
            GetComponent<AudioSource>().Play();
            half.SetActive(true);
            all.SetActive(false);

            elecList.Add(null);
            elecList.Add(null);
            elecList.Add(null);
            elecList.Add(null);

            if (elecList[0] == green && elecList[1] == red && elecList[2] == blue && elecList[3] == black)
            {
                //만약 정답이라면
                SoundManager.Instance.UIAudioPlay(UISound.Good);
                TVManager.Instance.ChangeTV();
                isOn = true;
            }
            else
            {
                //만약 틀렸다면
                red.Off();
                black.Off();
                green.Off();
                blue.Off();
                half.SetActive(false);
                all.SetActive(true);

                //전기 공격 (파티클)
                Instantiate(spark, transform.position, Quaternion.identity);

                BloodManager.Instance.Hurt(5);
                elecList.Clear();
            }
        }
    }

}
