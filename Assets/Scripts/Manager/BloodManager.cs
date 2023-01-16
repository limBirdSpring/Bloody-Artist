using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class BloodManager : SingleTon<BloodManager>, ISavable
{
    //�ǿ� ���õ� �͵� ����

    //---------------------[��ó��]-----------------------

    //��ó�� : 100�� ������ ���ӿ���
    [HideInInspector]
    public int hurtPercent { get; private set; } = 20;

    [SerializeField]
    private Image hurtSlide;//��ó�� �����̵�

    [SerializeField]
    private Image bloodImage;

    [SerializeField]
    private TextMeshProUGUI hurtText;

    //---------------------[�Ƿε�]-----------------------

    //�Ƿε� : ���ϼ��� �þ߰� �����
    private int tiredPercent = 30;

    [SerializeField]
    private Image tiredSlide;//�Ƿε� �����̵�

    [SerializeField]
    private int howMuchTired;



    //---------------------[�� ����]----------------------

    //�� ���� ����
    public List<BloodColor> bloodColor = new List<BloodColor>();

    //���� �� ��
    [SerializeField]
    private BloodColor curBloodColor;

    //��
    [SerializeField]
    private GameObject armTex;

    [SerializeField]
    private GameObject arm;

    //���� �����ϴ� ��ġ
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
    //                        �Ƿε�
    //==========================================================

    public void AddTired(int tired)//���ưų� Į�� �Ǹ� �긱 �� �Ƿε� ����
    {
       
        tiredPercent = Mathf.Clamp(tiredPercent + tired, 0, 100);
        float goal = 0.01f * tiredPercent;

        GameManager.Instance.Blind(goal);

        Debug.Log(tiredPercent);

        StartCoroutine(SlideCoroutine(tiredSlide, goal, true));

    }

    public void SubTired(int tired)//ö���� �԰� �Ƿε� ����
    {

        tiredPercent = Mathf.Clamp(tiredPercent-tired, 0, 100);
        float goal = 0.01f * tiredPercent;

        GameManager.Instance.Blind(goal);

        Debug.Log(tiredPercent);

        StartCoroutine(SlideCoroutine(tiredSlide, goal, false));

    }



    //==========================================================
    //                        ��ó��
    //==========================================================


    public void Hurt(int damage)
    {
        SoundManager.Instance.UIAudioPlay(UISound.Hurt);

        //�� �� ����
        ExpManager.Instance.SetExp("Red");

        //����ȭ�� �Ӱ� ����
        GameManager.Instance.BloodyScene();

        hurtPercent = Mathf.Clamp(hurtPercent + damage, 0, 100);

        AddTired(damage/2);

        float goal = 0.01f * hurtPercent;

        Debug.Log(hurtPercent);

        //�� ����߸�
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


    //��ó��,�Ƿε� �����̵忡 ���� �ڷ�ƾ
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
    //                          �� ����
    //==========================================================

    public void UsedKnife()
    {
        if (arm.activeSelf == false)
        {
            SoundManager.Instance.UIAudioPlay(UISound.UsedKnife);
            GameManager.Instance.ChangeCamToFront();
            //Į�� ����� ���� ���� �Ǹ� �긮�� �ִϸ��̼�
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
        //���� �� ���� �� ����߸�
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

        //��ó�� �����̵� ���� ����
        hurtSlide.sprite = curBloodColor.colorSlide;

        //�� �ؽ�ó ���� ����
        armTex.gameObject.GetComponent<SkinnedMeshRenderer>().material = curBloodColor.armMaterial;
    }
}
