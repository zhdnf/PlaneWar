using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class DeActive : MonoBehaviour
{
    bool isDestroy = false;
    [SerializeField] float delayTime = 0.2f;
    WaitForSeconds waitForSeconds;

    void Awake()
    {
        waitForSeconds = new WaitForSeconds(delayTime);
    }

    void OnEnable()
    {
        StartCoroutine(SelectDestroyWays());
    }

    IEnumerator SelectDestroyWays()
    {
        yield return waitForSeconds;
        if(isDestroy == false)
        {
            gameObject.GetComponent<DeActive>().enabled = false;
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
