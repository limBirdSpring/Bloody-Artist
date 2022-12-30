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
    //�ǿ� ���õ� �͵� ����

    //��ó�� : 100�� ������ ���ӿ���
    private int hurtPercent = 20;

    [SerializeField]
    private Image hurtSlide;//��ó�� �����̵�

    [SerializeField]
    private Image bloodImage;

    [SerializeField]
    private TextMeshProUGUI hurtText;

    //---------------------------------------------------

    //�Ƿε� : ���ϼ��� �þ߰� �����
    private int tiredPercent = 30;

    [SerializeField]
    private Image tiredSlide;//�Ƿε� �����̵�

    [SerializeField]
    private int howMuchTired;

    //���� �� ��
    [SerializeField]
    private BloodColor curBloodColor = BloodColor.Red; //get,set�߰�

 


    public void UsedKnife()
    {
        //Į�� ����� ���� ���� �Ǹ� �긮�� �ִϸ��̼�
    }

    public void DroppedGem()
    {
        //���� �� ���� �� ����߸�
    }

    public void AddTired(int tired)//���ưų� Į�� �Ǹ� �긱 �� �Ƿε� ����
    {
        tiredPercent = Mathf.Clamp(tiredPercent + tired, 0, 100);
        float goal = 0.01f * tiredPercent;

        Debug.Log(tiredPercent);

        StartCoroutine(SlideCoroutine(tiredSlide, goal, true));


        Blind();
    }

    public void SubTired(int tired)//ö���� �԰� �Ƿε� ����
    {
        tiredPercent = Mathf.Clamp(tiredPercent-tired, 0, 100);
        float goal = 0.01f * tiredPercent;

        Debug.Log(tiredPercent);

        StartCoroutine(SlideCoroutine(tiredSlide, goal, false));


        Blind();
    }

    public void Hurt(int damage)
    {
        //����ȭ�� �Ӱ� ����
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
        //�þ� �����
    }
}
