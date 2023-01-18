using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookBreakable : MonoBehaviour
{
    private bool miniGame = true;

    [SerializeField]
    private Sitable sit;

    [SerializeField]
    private GameObject particle;

    public void Break()
    {
        if (ItemManager.Instance.curSetItem.fileName == "Research")
        {
            if (miniGame)
            {
                InputManager.Instance.ChangeState(StateName.MiniGame);
                miniGame = false;
            }

            else
            {
                //¿«¿⁄ø° æ…¿∏∏È ∞Ê«Ë »πµÊ ∞°¥…
                GetComponent<AudioSource>()?.Play();
                InputManager.Instance.ChangeState(StateName.Idle);
                sit.isExpGetable = true;
                Instantiate(particle, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

        }
    }
}
