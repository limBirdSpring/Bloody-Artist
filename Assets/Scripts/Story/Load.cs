using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.SceneChange("MainMap");

    }
}
