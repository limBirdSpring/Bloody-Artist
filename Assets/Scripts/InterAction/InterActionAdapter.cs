using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InterActionAdapter : MonoBehaviour
{
    public UnityEvent OnInterAction;

    public void Interaction()
    {
        OnInterAction?.Invoke();
    }
}
