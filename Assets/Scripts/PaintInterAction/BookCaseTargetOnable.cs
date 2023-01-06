using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCaseTargetOnable : MonoBehaviour
{
    public bool isOn { get; private set; } = false;

    public void TargetOn()
    {

        //완료 소리 재생
        Debug.Log("페인트볼");
        isOn = true;
        BookCaseToArcade.Instance.ArcadeOn();
    }
}
