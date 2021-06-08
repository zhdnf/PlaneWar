using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class ItemDropRule : MonoBehaviour
{
    public Item item;
    public float dropRatio;

    private void Start()
    {
        
    }

    public void Execute(Transform target)
    {
        if (Random.Range(0f, 100f) <= dropRatio)
        {
            Item dropItem = Instantiate<Item>(item);
            dropItem.transform.position = target.transform.position;
        }
    }
}
