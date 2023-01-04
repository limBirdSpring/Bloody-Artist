using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PaintAdapter : MonoBehaviour
{
    public UnityEvent OnInterAction = null;

    public void PaintInteraction()
    {
        OnInterAction?.Invoke();
    }
}
