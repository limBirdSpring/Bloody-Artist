using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControler : MonoBehaviour
{
    [SerializeField]
    private Animator maskSwitch;

    [SerializeField]
    private Animator mediaSwitch;

    [SerializeField]
    private Animator hallSwitch;

    [SerializeField]
    private Animator hallDoor;

    [SerializeField]
    private Animator maskDoor;

    [SerializeField]
    private Animator mediaDoor;

    [SerializeField]
    private Animator yayoyiDoor;


    private void Update()
    {
        if (hallSwitch.GetBool("IsOn"))
        {
            hallDoor.gameObject.GetComponent<AudioSource>().Play();
            hallDoor.SetBool("IsOpen", true);
        }
        else if (!hallSwitch.GetBool("IsOn"))
        {
            hallDoor.gameObject.GetComponent<AudioSource>().Play();
            hallDoor.SetBool("IsOpen", false);
        }

        if (maskSwitch.GetBool("IsOn"))
        {
            maskDoor.gameObject.GetComponent<AudioSource>().Play();
            maskDoor.SetBool("IsOpen", true);

            hallSwitch.SetBool("IsOn", false);

        }
        else if (!maskSwitch.GetBool("IsOn"))
        {

            maskDoor.gameObject.GetComponent<AudioSource>().Play();
            maskDoor.SetBool("IsOpen", false);
        }

        if (mediaSwitch.GetBool("IsOn"))
        {
            mediaDoor.gameObject.GetComponent<AudioSource>().Play();
            mediaDoor.SetBool("IsOpen", true);
            yayoyiDoor.gameObject.GetComponent<AudioSource>().Play();
            yayoyiDoor.SetBool("IsOpen", true);

            hallSwitch.SetBool("IsOn", false);
        }
        else if (!mediaSwitch.GetBool("IsOn"))
        {
            mediaDoor.gameObject.GetComponent<AudioSource>().Play();
            mediaDoor.SetBool("IsOpen", false);
            yayoyiDoor.gameObject.GetComponent<AudioSource>().Play();
            yayoyiDoor.SetBool("IsOpen", false);

            if (GameManager.Instance.isRunMode)
                GameManager.Instance.EndRunMode();
        }
    }


}
