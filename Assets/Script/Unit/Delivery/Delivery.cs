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
    public float minRange = 1f; 
    public float maxRange = 5f; 

    public GameObject[] itemTeplate;
    public GameObject fxExplode;

    private void Start()
    {
        onStart();
    }
    public override void onStart()
    {

        this.HP = this.maxHP = 10f;   
        this.anim = this.GetComponent<DeliveryAnimation>();
        float initX = Random.Range(minRange, maxRange);
        this.transform.position = new Vector3(initX, this.transform.position.y, 0);
        // Utility.Instance.Animation(this.GetComponent<DeliveryAnimation>(), "Active");
    }

    // public override void Dead()
    // {
    //     Utility.Instance.Animation(this.GetComponent<DeliveryAnimation>(), "Boom");
    // }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        onUpdate();
    }

    public override void onUpdate()
    {
        base.onUpdate();
        if (!Utility.Instance.InScreen(this.transform.position))
        {
            gameObject.GetComponent<DeActive>().enabled = false;
        }
        
    }


    public void OnDeliveryBoom()
    {
        //gameObject.GetComponent<DeActive>().enabled = false;
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
