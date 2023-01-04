using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCaseToArcade : MonoBehaviour
{
    [SerializeField]
    private List<Arcade> arcades = new List<Arcade>();

    

    public void ArcadeOn()
    {
        for(int i = 0; i < arcades.Count; i++)
        {
            arcades[i].AppearGhost();
        }
    }
}
