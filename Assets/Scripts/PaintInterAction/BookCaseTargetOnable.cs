using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCaseTargetOnable : MonoBehaviour
{
    public bool isOn { get; private set; } = false;

    public void TargetOn()
    {
        Debug.Log("����Ʈ��");
        isOn = true;
        BookCaseToArcade.Instance.ArcadeOn();
    }
}
