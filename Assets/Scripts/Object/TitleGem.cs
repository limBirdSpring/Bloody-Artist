using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class TitleGem : MonoBehaviour
{

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


        yield return new WaitForSeconds(0.1f);

        elec.gameObject.SetActive(true);

        //배경
        backGround.gameObject.SetActive(true);

        yield return new WaitForSeconds(1.2f);
        //손
        arm.SetActive(true);
       

        yield return new WaitForSeconds(1.2f);
        //타이틀
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
