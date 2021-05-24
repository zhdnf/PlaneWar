using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class Item : Singleton<Item> 
{

    public ITEMTYPE type;

    private void Update()
    {
        this.transform.position += new Vector3(0, -1f * Time.deltaTime, 0);
        if (!Utility.Instance.InScreen(this.transform.position))
        {
            Destroy(this.gameObject);
        }
    }

    public virtual void Use(Player player)
    {
        // use item
    }
}
