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

    public float minRange = -3;
    public float maxRange = 3;

    public ENEMYTYPE enemyType;

    //test
    public float destoryTimer = 0f;


    private void Start()
    {
        this.onStart();
    }

    public override void onStart()
    {
        this.Init();
    }

    private void Update()
    {
        this.onUpdate();
    }

    // 敌人的活动
    public virtual void onUpdate()
    {
        // 在屏幕外就删除

        this.initY = this.transform.position.y;

        float offsetY = 0;
        if(this.enemyType == ENEMYTYPE.SWING)
        {
            offsetY = Mathf.Sin(Time.timeSinceLevelLoad) * 0.01f;
        }

        if(this.enemyType == ENEMYTYPE.BOSS)
        {
            return;
        }

        this.transform.position = new Vector3(this.transform.position.x - 1 * Time.deltaTime * speed, initY + offsetY, 0);
        fireTimer += Time.deltaTime;
        Fire(this.bulletTemple);

        if (Screen.safeArea.Contains(Camera.main.WorldToScreenPoint(this.transform.position)) == false)
        {
            Destroy(this.gameObject, 1f);
        }

    }


    // Enemy的状态方法
    public void Init()
    {
        //this.Idle();
        initY = Random.Range(minRange, maxRange);
        this.transform.localPosition = new Vector3(0, Random.Range(minRange, maxRange), 0);
        this.Fly(this.transform.position.y);
    }

    public virtual void Fly(float y)
    {
        base.Fly(y);
    }

    public void Dead()
    {

        if (rigidbodyBrid.bodyType == RigidbodyType2D.Kinematic)
            rigidbodyBrid.bodyType = RigidbodyType2D.Dynamic;
        
        // 死亡时下落(暂替死亡动画)
        // playerAnimation.DownFly();
       
        Destroy(this.gameObject, 0.1f);
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(gameObject.name + " triggered with " + col.gameObject.name);
        Bullet bullet = col.gameObject.GetComponent<Bullet>();
        if (bullet != null && bullet.side == SIDE.PLAYER)
        {
            this.Dead();
        }
    }


    void OnCollisionEnter(Collision col)
    {
        Debug.Log(gameObject.name + " collided with " + col.gameObject.name);

    }



    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(gameObject.name + " triggerred exit " + collision.gameObject.name);
        if (collision.gameObject.name.Equals("Ground"))
        {
            if (rigidbodyBrid.bodyType == RigidbodyType2D.Dynamic)
                rigidbodyBrid.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    protected override void BulletInit(Bullet bullet)
    {
        bullet.GetComponent<Bullet>().direction = Vector3.left;
    }


}
