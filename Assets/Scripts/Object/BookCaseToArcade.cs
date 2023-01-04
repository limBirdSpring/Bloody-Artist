using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCaseToArcade : SingleTon<BookCaseToArcade>
{
    [SerializeField]
    private List<Arcade> arcades = new List<Arcade>();

    [SerializeField]
    private List<BookCaseTargetOnable> bookcollider = new List<BookCaseTargetOnable>();
    

    public void ArcadeOn()
    {
        for(int i=0; i< bookcollider.Count;i++)
        {
            if (bookcollider[i].isOn == false)
                return;
        }
        for(int i = 0; i < arcades.Count; i++)
        {
            arcades[i].AppearGhost();
        }
    }
}
