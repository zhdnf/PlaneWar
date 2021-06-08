using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
*/

/// <summary>
///
/// </summary>

public class Enemy : Unit 
{
    // 记录原本的位置->实现SWING
    float initY;

    public float lifeTime = 4f;

    public float minRange = -3;
    public float maxRange = 3;


    // 敌人类型
    public ENEMYTYPE enemyType;

    public Vector3 direction = Vector3.right;

    //test
    public float destoryTimer = 0f;


    private void Start()
    {
        this.onStart();
    }

    public override void onStart()
    {
        // Destroy(this.gameObject, lifeTime);
        anim = GetComponent<EnemyAnimation>();
        initY = Random.Range(minRange, maxRange);
        this.transform.position = new Vector3(this.transform.position.x, initY, 0);
        this.Fly(anim);
    }

    private void Update()
    {
        this.onUpdate();
    }

    // 敌人的活动
    public override void onUpdate()
    {
        // 定义摇摆的偏移量
        float offsetY = 0;

        if (this.enemyType == ENEMYTYPE.SWING)
        {
            offsetY = Mathf.Sin(Time.timeSinceLevelLoad) * 0.01f;
            this.power = 10;
        }

        this.transform.position = new Vector3(this.transform.position.x - 1 * Time.deltaTime * speed, this.transform.position.y + offsetY, 0);

        Fire(this.bulletTemple, this.power);

        if (!Utility.Instance.InScreen(this.transform.position))
        {
            gameObject.GetComponent<DeActive>().enabled = false;
        }

    }


    public virtual void  OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(gameObject.name + " triggered with " + col.gameObject.name);
        Bullet bullet = col.gameObject.GetComponent<Bullet>();
        
        if(col.gameObject.name.Equals("Atomic(clone)"))
        {
            this.Dead(anim);
        }

        if (bullet != null && bullet.side == SIDE.PLAYER)
        {
            if (this.HP > 0f)
            {
                this.Damage(bullet.power); 
            }
            else
            {
                this.Dead(anim);
            }
        }
    }


    public virtual void  OnCollisionEnter(Collision col)
    {
        Debug.Log(gameObject.name + " collided with " + col.gameObject.name);

    }


    public  virtual void OnTriggerExit2D(Collider2D collision)
    {
    }


}
