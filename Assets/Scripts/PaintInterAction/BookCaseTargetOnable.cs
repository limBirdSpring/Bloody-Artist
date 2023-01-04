using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCaseTargetOnable : MonoBehaviour
{
    public bool isOn { get; private set; } = false;

    public void TargetOn()
    {
        Debug.Log("페인트볼");
        isOn = true;
        BookCaseToArcade.Instance.ArcadeOn();
    }
}
