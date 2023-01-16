using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Note : MonoBehaviour
{

    [SerializeField]
    private GameObject mainRoom1;

    [SerializeField]
    private GameObject mainRoomEnding;
    
    public void NewNote()
    {

        if (GameManager.Instance.story == 4)
        {
            GetComponent<Researchable>().enabled = false;

            SoundManager.Instance.SetBgm(BGMSound.None);

            //경험 모두 삭제 후 검정색만 추가, 노래 멈췄다가 다시 울림, 전시회장 엔딩으로 진입
            ExpManager.instance.DeleteExp("Red");
            ExpManager.instance.DeleteExp("Blue");
            ExpManager.instance.DeleteExp("White");
            ExpManager.instance.DeleteExp("Yellow");
            ExpManager.instance.DeleteExp("Pink");
            ExpManager.instance.DeleteExp("Green");

            StartCoroutine(NoteCoroutine());


        }

        
    }

    private IEnumerator NoteCoroutine()
    {
        yield return new WaitForSeconds(2f);
        ExpManager.instance.AddExp("Black");

        mainRoom1.SetActive(false);
        mainRoomEnding.SetActive(true);
    }
}
