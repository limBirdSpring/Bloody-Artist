using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BloodColor", menuName = "BloodColor")]
public class BloodColor : ScriptableObject
{
    public string name;
    public Sprite colorSlide;
    public Texture2D handTexture;
    public GameObject gem;
}
