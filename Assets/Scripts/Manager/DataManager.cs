using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using File = System.IO.File;
using Unity.VisualScripting;
using System;




public class DataManager : SingleTon<DataManager>
{
    string path;
    string filename = "Save";

    [HideInInspector]
    public string data;

    private void Awake()
    {
        path = Application.persistentDataPath + "/";
    }

    public void SaveData()
    {
        data = "";

        //FindObjectsOfType<GetableItem>()
        Savable[] savable = FindObjectsOfType<Savable>();
        foreach(Savable s in savable)
        {
            s.Save();
        }

        //data = JsonUtility.ToJson(gameData);
        File.WriteAllText(path + filename, data);

        Debug.Log("저장완료");
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + filename);
        GameManager.Instance.SceneChange("MainMap");
        JsonUtility.FromJson<Savable[]>(data);
    }
}
