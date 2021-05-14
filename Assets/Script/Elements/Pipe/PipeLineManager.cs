using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class PipeLineManager : MonoBehaviour
{
    public Object template;
    Coroutine coroutine = null;

    public List<PipeLine> pipeList = new List<PipeLine>();
    
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

            yield return new WaitForSeconds(2f);
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
