using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum BloodColor
{
    Red,
    Green,
    Blue,
    White,
    Pink,
    Black,
    Size

}

public class BloodManager : SingleTon<BloodManager>
{
    //피에 관련된 것들 진행

    //상처율 : 100이 넘으면 게임오버
    private int hurtPercent = 20;

    [SerializeField]
    private Image hurtSlide;//상처율 슬라이드

    [SerializeField]
    private Image bloodImage;

    [SerializeField]
    private TextMeshProUGUI hurtText;

    //---------------------------------------------------

    //피로도 : 쌓일수록 시야가 흐려짐
    private int tiredPercent = 30;

    [SerializeField]
    private Image tiredSlide;//피로도 슬라이드

    [SerializeField]
    private int howMuchTired;

    //현재 피 색
    [SerializeField]
    private BloodColor curBloodColor = BloodColor.Red; //get,set추가

 


    public void UsedKnife()
    {
        //칼을 사용해 현재 색의 피를 흘리는 애니메이션
    }

    public void DroppedGem()
    {
        //현재 피 색의 젬 떨어뜨림
    }

    public void AddTired(int tired)//다쳤거나 칼로 피를 흘릴 때 피로도 증가
    {
        tiredPercent = Mathf.Clamp(tiredPercent + tired, 0, 100);
        float goal = 0.01f * tiredPercent;

        Debug.Log(tiredPercent);

        StartCoroutine(SlideCoroutine(tiredSlide, goal, true));


        Blind();
    }

    public void SubTired(int tired)//철분제 먹고 피로도 감소
    {
        tiredPercent = Mathf.Clamp(tiredPercent-tired, 0, 100);
        float goal = 0.01f * tiredPercent;

        Debug.Log(tiredPercent);

        StartCoroutine(SlideCoroutine(tiredSlide, goal, false));


        Blind();
    }

    public void Hurt(int damage)
    {
        //게임화면 붉게 변함
        GameManager.Instance.BloodyScene();

        hurtPercent = Mathf.Clamp(hurtPercent + damage, 0, 100);

        float goal = 0.01f * hurtPercent;

        Debug.Log(hurtPercent);

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

    private void Blind()
    {
        //시야 흐려짐
    }
}
