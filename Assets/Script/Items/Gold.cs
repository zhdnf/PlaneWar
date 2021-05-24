using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class Gold : Item
{
    public void Start()
    {
        this.type = ITEMTYPE.GLOD;
    }

    public override void Use(Player player)
    {
        base.Use(player);
        MyUI.Instance.OnGold(++player.goldNums);
        Destroy(this.gameObject);
    }
}
