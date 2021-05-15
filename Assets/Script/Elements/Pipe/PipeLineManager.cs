using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
/// 只产生了三个管道， 流程走完返回起点
/// </summary>

public class PipeLineManager : MonoBehaviour
{
    public Object template;
    Coroutine coroutine = null;

    public List<PipeLine> pipeList = new List<PipeLine>();

    //产生管道的速度
    public float speed = 2f;
    
    void Start()
    {

    }

    public void PipeLineManagerStart()
    {

        coroutine = StartCoroutine(GeneratorsPipeLine());

    }

    public void PipeLineManagerStop()
    {
        StopCoroutine(coroutine);
        for (int i = 0; i < pipeList.Count; i++)
        {
            pipeList[i].enabled = false;
        }
    }
    IEnumerator GeneratorsPipeLine()
    {
        for(int i = 0; i<3; i++)
        {
            if(pipeList.Count < 3)
            {
                GeneratePipeLine();
            }
            else
            {
                pipeList[i].enabled = true;
                pipeList[i].PipeLineInit();
            }

            yield return new WaitForSeconds(speed);
        }
        
        
    }

    public void GeneratePipeLine()
    {
        if(pipeList.Count < 3) {
            //实例化对象
            GameObject pipeObject = Instantiate(template, this.transform) as GameObject;
            PipeLine p = pipeObject.GetComponent<PipeLine>();
            pipeList.Add(p);
        }
    }

    public void Init()
    {
        for(int i=0; i<pipeList.Count; i++)
        {
            Destroy(pipeList[i].gameObject);
        }
        pipeList.Clear();
    }

}
