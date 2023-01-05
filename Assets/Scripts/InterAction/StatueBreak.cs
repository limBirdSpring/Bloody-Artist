using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueBreak : MonoBehaviour
{
    [SerializeField]
    private GameObject amber;

    private bool miniGame = true;

    public void Break()
    {
        if (GameManager.Instance.IsCurCursor("Research")) //경매가 시작되었을때도 분류
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
                    Instantiate(amber, transform.position, transform.rotation);
                }
                Destroy(gameObject);
            }
        }
    }
}
