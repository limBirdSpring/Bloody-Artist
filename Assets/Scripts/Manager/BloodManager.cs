using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BloodManager : SingleTon<BloodManager>, ISavable
{
    //피에 관련된 것들 진행

    //---------------------[상처율]-----------------------

    //상처율 : 100이 넘으면 게임오버
    [HideInInspector]
    public int hurtPercent { get; private set; } = 20;

    [SerializeField]
    private Image hurtSlide;//상처율 슬라이드

    [SerializeField]
    private Image bloodImage;

    [SerializeField]
    private TextMeshProUGUI hurtText;

    //---------------------[피로도]-----------------------

    //피로도 : 쌓일수록 시야가 흐려짐
    private int tiredPercent = 30;

    [SerializeField]
    private Image tiredSlide;//피로도 슬라이드

    [SerializeField]
    private int howMuchTired;



    //---------------------[피 색깔]----------------------

    //피 색깔 모음
    public List<BloodColor> bloodColor = new List<BloodColor>();

    //현재 피 색
    [SerializeField]
    private BloodColor curBloodColor;

    //팔
    [SerializeField]
    private GameObject armTex;

    [SerializeField]
    private GameObject arm;

    //젬을 생성하는 위치
    [SerializeField]
    private Transform gemTrans;


    //---------------------------------------------------


    public void OnSave()
    {
        DataManager.Instance.data += JsonUtility.ToJson(hurtPercent);
        DataManager.Instance.data += JsonUtility.ToJson(tiredPercent);
        DataManager.Instance.data += JsonUtility.ToJson(curBloodColor);
    }


    private void Start()
    {
        curBloodColor = bloodColor[0];
    }



    //==========================================================
    //                        피로도
    //==========================================================

    public void AddTired(int tired)//다쳤거나 칼로 피를 흘릴 때 피로도 증가
    {
       
        tiredPercent = Mathf.Clamp(tiredPercent + tired, 0, 100);
        float goal = 0.01f * tiredPercent;

        GameManager.Instance.Blind(goal);

        Debug.Log(tiredPercent);

        StartCoroutine(SlideCoroutine(tiredSlide, goal, true));

    }

    public void SubTired(int tired)//철분제 먹고 피로도 감소
    {

        tiredPercent = Mathf.Clamp(tiredPercent-tired, 0, 100);
        float goal = 0.01f * tiredPercent;

        GameManager.Instance.Blind(goal);

        Debug.Log(tiredPercent);

        StartCoroutine(SlideCoroutine(tiredSlide, goal, false));

    }



    //==========================================================
    //                        상처율
    //==========================================================


    public void Hurt(int damage)
    {
        SoundManager.Instance.UIAudioPlay(UISound.Hurt);

        //피 색 변경
        ExpManager.Instance.SetExp("Red");

        //게임화면 붉게 변함
        GameManager.Instance.BloodyScene();

        hurtPercent = Mathf.Clamp(hurtPercent + damage, 0, 100);

        AddTired(damage/2);

        float goal = 0.01f * hurtPercent;

        Debug.Log(hurtPercent);

        //젬 떨어뜨림
        DroppedGem();

        StartCoroutine(SlideCoroutine(hurtSlide, goal, true));

        if (hurtPercent >= 100)
            GameManager.Instance.GameOver();
        else if (hurtPercent >= 70)
            bloodImage.gameObject.SetActive(true);



    }

    public void Heal(int damage)
    {
         
        hurtPercent = Mathf.Clamp(hurtPercent - damage, 0, 100);

        float goal = 0.01f * hurtPercent;

        StartCoroutine(SlideCoroutine(hurtSlide, goal, false));

        if (hurtPercent < 70)
            bloodImage.gameObject.SetActive(false);
    }

    private void UpdateHurtText()
    {
        hurtText.text = (int)(hurtSlide.fillAmount * 100) + "%";
    }


    //상처율,피로도 슬라이드에 대한 코루틴
    private IEnumerator SlideCoroutine(Image slide, float goal, bool add)
    {
        if (add)
        {
            while (goal > slide.fillAmount && slide.fillAmount <= 100)
            {
                yield return new WaitForSeconds(0.05f);
                slide.fillAmount += 0.01f;

                if (slide == hurtSlide)
                    UpdateHurtText();
            }
        }
        else
        {
            while (goal < slide.fillAmount && slide.fillAmount >= 0)
            {
                yield return new WaitForSeconds(0.05f);
                slide.fillAmount -= 0.01f;

                if (slide == hurtSlide)
                    UpdateHurtText();
            }
        }
    }


    public void ResetBlood()
    {
        hurtPercent = 40;
        tiredPercent = 0;
        hurtSlide.fillAmount = 0.4f;
        tiredSlide.fillAmount = 0f;
    }

    //==========================================================
    //                          피 관련
    //==========================================================

    public void UsedKnife()
    {
        if (arm.activeSelf == false)
        {
            SoundManager.Instance.UIAudioPlay(UISound.UsedKnife);
            GameManager.Instance.ChangeCamToFront();
            //칼을 사용해 현재 색의 피를 흘리는 애니메이션
            arm.SetActive(true);
            StartCoroutine(ActiveKnife());
        }
    }

    private IEnumerator ActiveKnife()
    {
        yield return new WaitForSeconds(2.4f);
        arm.SetActive(false);
        AddTired(10);
        DroppedGem();
        GameManager.Instance.ExitCamFromFront();
    }

    private void DroppedGem()
    {
        //현재 피 색의 젬 떨어뜨림
        GameObject obj = Instantiate(curBloodColor.gem, gemTrans.position, gemTrans.rotation);
        obj.name = curBloodColor.gem.name;
    }

    public void ChangeBloodColor(string color)
    {
        for (int i=0; i < bloodColor.Count; i++)
        {
            if (color == bloodColor[i].name)
            {
                curBloodColor = bloodColor[i];
                break;
            }
        }

        //상처율 슬라이드 색상 변경
        hurtSlide.sprite = curBloodColor.colorSlide;

        //팔 텍스처 색깔 변경
        armTex.gameObject.GetComponent<SkinnedMeshRenderer>().material = curBloodColor.armMaterial;
    }
}
