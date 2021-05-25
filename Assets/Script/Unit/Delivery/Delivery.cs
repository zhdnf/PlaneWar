using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class Delivery : Unit
{

    public float lifeTiem = 10f;
    public GameObject[] itemTeplate;
    public GameObject fxExplode;

    private void Start()
    {
        onStart();
    }
    public override void onStart()
    {
        base.onStart();
        this.HP = this.maxHP = 10f;
        Utility.Instance.Animation(this.GetComponent<DeliveryAnimation>(), "Active");
    }

    public override void Dead()
    {
        Utility.Instance.Animation(this.GetComponent<DeliveryAnimation>(), "Boom");
    }


    public void OnDeliveryBoom()
    {
        Destroy(this.gameObject);
        Instantiate(fxExplode, this.transform.position, Quaternion.identity);
    }

    public void GenerateItem()
    {
        int index = Random.Range(0, itemTeplate.Length);
        GameObject temp = Instantiate(itemTeplate[index]);
        Item item = temp.GetComponent<Item>();
        item.transform.position = this.transform.position;

    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(gameObject.name + " triggered with " + col.gameObject.name);
        Bullet bullet = col.gameObject.GetComponent<Bullet>();
        if (bullet != null && bullet.side == SIDE.PLAYER)
        {
            this.Damage(bullet.power);
        }
    }
}
