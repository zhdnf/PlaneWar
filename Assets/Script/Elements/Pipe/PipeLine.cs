using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class PipeLine : MonoBehaviour
{
    public float speed = 1;
    public float minRange = -3;
    public float maxRange = 3;

    float t = 0;

    void Start()
    {
        this.PipeLineInit();
    }

    void Update()
    {
        this.transform.position += new Vector3(-speed, 0) * Time.deltaTime;
        t = t + Time.deltaTime;
        if (t > 7f)
        {
            t = 0;
            this.PipeLineInit();
        }
    }

    public void PipeLineInit()
    {
        this.transform.localPosition = new Vector3(0, Random.Range(minRange, maxRange), 0);
    }


}
