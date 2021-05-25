using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class Apple : Item
{
    private float HealHP = 10f;

    public void Start()
    {
        this.type = ITEMTYPE.APPLE;
    }

    public override void Use(Player player)
    {
        base.Use(player);
        player.HP += HealHP;
        if(player.HP > player.maxHP)
        {
            player.HP = player.maxHP;
        }
        Destroy(this.gameObject);
    }
}

