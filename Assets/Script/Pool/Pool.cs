using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

[System.Serializable]
public class Pool
{
    [SerializeField] public GameObject prefab;

    public int Size => size;
    public int RuntimeSize => queue.Count;


    [SerializeField] int size;
    Queue<GameObject> queue;

    Transform parent;

    public void Initialize(Transform parent)
    {
        queue = new Queue<GameObject>();
        this.parent = parent;
        for(var i=0; i<size; i++)
        {
            queue.Enqueue(Copy());
        }
    }

    GameObject Copy()
    {
        var copy = GameObject.Instantiate(prefab, parent);
        copy.SetActive(false);
        return copy;    
    }

    GameObject AvaiableObject()
    {
        GameObject availableObject = null;
        if(queue.Count > 0 && !queue.Peek().activeSelf)
        {
            availableObject = queue.Dequeue();
        }
        else
        {
            availableObject = Copy();
        }

        queue.Enqueue(availableObject);

        return availableObject;
    }

    public GameObject preparedObject()
    {
        GameObject preparedObject = AvaiableObject();
        preparedObject.SetActive(true);
        return preparedObject;
    }

    public GameObject preparedObject(Vector3 position)
    {
        GameObject preparedObject = AvaiableObject();
        preparedObject.SetActive(true);
        preparedObject.transform.position = position;
        return preparedObject;
    }

    public GameObject preparedObject(Vector3 position, Quaternion rotation)
    {
        GameObject preparedObject = AvaiableObject();
        preparedObject.SetActive(true);
        preparedObject.transform.position = position;
        preparedObject.transform.rotation = rotation;
        return preparedObject;
    }


    

}
