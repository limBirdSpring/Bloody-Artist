using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savable : MonoBehaviour
{
    public void Save()
    {
        ISavable savable = GetComponent<ISavable>();
        savable?.OnSave();
    }
}
