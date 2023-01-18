using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDoor : MonoBehaviour
{
    private bool isOpen = false;

    [SerializeField]
    private AudioClip clip;
    
    public void Knock()
    {
        if (!isOpen && GameManager.Instance.IsCurCursor("Research"))
        {
            SoundManager.Instance.SetBgm(BGMSound.None);
            StartCoroutine(KnockCor());
        }
    }

    private IEnumerator KnockCor()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);
        SoundManager.Instance.SetBgm(BGMSound.Playing);

        if (ExpManager.Instance.isExpHave("Yellow") && ExpManager.Instance.isExpHave("Pink"))
        {
            GetComponent<AudioSource>().clip = clip;
            GetComponent<AudioSource>().Play();
            GetComponent<Animator>().SetTrigger("Open");
            isOpen = true;
        }
    }    
}
