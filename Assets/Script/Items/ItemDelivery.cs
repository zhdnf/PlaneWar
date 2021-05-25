using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class ItemDelivery : Singleton<ItemDelivery>
{
    public List<Delivery> itemsList = new List<Delivery>();


    public Delivery GenerateItem(GameObject itemTemplates)
    {
        if (itemTemplates == null)
        {
            return null;
        }

        //实例化对象
        GameObject itemsObject = Instantiate(itemTemplates, this.transform) as GameObject;
        Delivery d = itemsObject.GetComponent<Delivery>();
        this.itemsList.Add(d);
        return d;
    }


}
