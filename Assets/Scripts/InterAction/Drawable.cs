using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawable : MonoBehaviour
{


    public void Draw()
    {
        if (GameManager.Instance.IsCurCursor("PaintRoller"))
        {
            if(ItemManager.Instance.FindItemNum("Red")==2 &&
                ItemManager.Instance.FindItemNum("Blue") == 2 &&
                ItemManager.Instance.FindItemNum("Black") == 2 &&
                ItemManager.Instance.FindItemNum("Green") == 2)
            {

            }
            else
            {

            }
        }

    }
}
