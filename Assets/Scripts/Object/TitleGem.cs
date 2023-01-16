using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class TitleGem : MonoBehaviour
{

    [SerializeField]
    private GameObject logo;

    [SerializeField]
    private GameObject logoCanvas;

    [SerializeField]
    private GameObject gem;

    [SerializeField]
    private GameObject arm;

    [SerializeField]
    private Image title;

    [SerializeField]
    private Image backGround;

    [SerializeField]
    private GameObject ui;

    [SerializeField]
    private Image elec;

    [SerializeField]
    private Image lighting;

    private int num = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Gem());
    }

    private IEnumerator Gem()
    {

        //�ΰ� �����ֱ�
        yield return new WaitForSeconds(2f);
        logo.SetActive(true);


        yield return new WaitForSeconds(7f);
        logoCanvas.SetActive(false);
        

        //BGM���
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(0.7f);

        elec.gameObject.SetActive(true);

        //���
        backGround.gameObject.SetActive(true);

        yield return new WaitForSeconds(1.2f);
        //��
        arm.SetActive(true);
       

        yield return new WaitForSeconds(1.2f);
        //Ÿ��Ʋ
        arm.GetComponent<Animator>().SetTrigger("Move");
        title.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);
        title.GetComponent<Animator>().SetTrigger("Fade");
        yield return new WaitForSeconds(2f);
        lighting.gameObject.SetActive(true);
        //UI
        ui.SetActive(true);

        while (num < 10)
        {
            yield return new WaitForSeconds(5f);

            Instantiate(gem, transform.position, transform.rotation);
            num++;
        }
    }
}
