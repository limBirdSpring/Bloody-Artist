using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
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

            //���� ��� ���� �� �������� �߰�, �뷡 ����ٰ� �ٽ� �︲, ����ȸ�� �������� ����
           ExpManager.Instance.ClearExp();
           
           ExpManager.Instance.AddExp("Black");
            BloodManager.Instance.ChangeBloodColor("Black");
            mainRoom1.SetActive(false);
            mainRoomEnding.SetActive(true);
        }

        
    }
}
