using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuprisedCamera : MonoBehaviour
{

    [SerializeField]
    private CinemachineVirtualCamera cam;

    [SerializeField]
    private CinemachineBrain brain;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            InputManager.Instance.ChangeState(StateName.Block);
            GetComponent<AudioSource>().Play();
            cam.Priority = 20;
            brain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;
            StartCoroutine(Cor());
        }
    }

    private IEnumerator Cor()
    {
        yield return new WaitForSeconds(2f);
        cam.Priority = 1;
        InputManager.Instance.ChangeState(StateName.Idle);
        yield return new WaitForSeconds(1f);
        brain.m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.EaseInOut;
        Destroy(gameObject);
    }

}
