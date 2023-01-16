using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueBreak : MonoBehaviour
{
    [SerializeField]
    private GameObject amber;

    [SerializeField]
    private GameObject particle;

    private bool miniGame = true;

    public void Break()
    {
        if (GameManager.Instance.IsCurCursor("Research") && AuctionManager.Instance.isStartAuction)
        {
            if (miniGame)
            {
                InputManager.Instance.ChangeState(StateName.MiniGame);
                miniGame = false;
            }
            else
            {
                GetComponent<AudioSource>().Play();
                if (amber != null)
                {
                    amber.SetActive(true);
                }

                Instantiate(particle, transform.position, Quaternion.identity);
                Destroy(gameObject);
                InputManager.Instance.ChangeState(StateName.Idle);
            }
        }
    }
}
