using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackRoonDoor : MonoBehaviour
{
    [SerializeField]
    private Transform playerEndPos;

    [SerializeField]
    private GameObject light;

    [SerializeField]
    private GameObject blackRoom;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            light.SetActive(false);
            InputManager.Instance.ChangeState(StateName.Block);
            other.transform.position = playerEndPos.position;

            
        }
    }

    private IEnumerator TriggerCor()
    {
        yield return new WaitForSeconds(0.5f);

        InputManager.Instance.ChangeState(StateName.Idle);
        ExpManager.Instance.AddExp("White");
        blackRoom.SetActive(false);
    }
}
