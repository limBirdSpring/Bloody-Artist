using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(Load());
    }

    private IEnumerator Load()
    {
        yield return null;

        AsyncOperation scene = SceneManager.LoadSceneAsync("MainMap");

        scene.allowSceneActivation = false;

        float timeC = 0;

        while(!scene.isDone)
        {
            yield return null;
            timeC += Time.deltaTime;

            //���丮 ȭ�� ����

            //scene.allowSceneActivation = true;
        }
    }
}
