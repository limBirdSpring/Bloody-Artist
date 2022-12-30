using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Log
{
    public string name;
    public string log;
}

[CreateAssetMenu(fileName = "dlog", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    public int questNum;

    public List<Log> dialogue = new List<Log>();
}
