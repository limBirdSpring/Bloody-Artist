using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleGem : MonoBehaviour
{

    [SerializeField]
    private GameObject gem;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Gem());
    }

    private IEnumerator Gem()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);

            Instantiate(gem, transform.position, transform.rotation);
        }
    }
}
