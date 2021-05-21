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
        initY = Random.Range(minRange, maxRange);
        this.transform.localPosition = new Vector3(0, initY, 0);
        this.Fly();
    }

    private void Update()
    {
        this.onUpdate();
    }

    // 敌人的活动
    public virtual void onUpdate()
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

    }


    public virtual void Fly()
    {
        AnimationStrategy.Instance.Strategy = this.GetComponent<EnemyAnimation>();
        AnimationStrategy.Instance.Strategy.Action("idle");
    }

    public virtual void Dead()
    {
        base.Dead();
        AnimationStrategy.Instance.Strategy = this.GetComponent<EnemyAnimation>();
        AnimationStrategy.Instance.Strategy.Action("dead");
    }



    public virtual void  OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(gameObject.name + " triggered with " + col.gameObject.name);
        Bullet bullet = col.gameObject.GetComponent<Bullet>();
        if (bullet != null && bullet.side == SIDE.PLAYER)
        {
            if (this.HP > 0f)
            {
                this.Damage(bullet.power); 
            }
            else
            {
                this.Dead();
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
