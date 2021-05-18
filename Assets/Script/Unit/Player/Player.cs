using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
*/

/// <summary>
/// player交互相关的方法
/// </summary>

public class Player : Unit
{


    // 分数委托
    public UnityAction<int> onScore;

    // 血量委托
    public UnityAction<float> onHP;

    // 死亡委托
    public delegate void DeathModify();
    public event DeathModify OnDeath;


    //test
    public float Force = 5f;

    private void Start()
    {
        this.onStart();
    }

    public override void onStart()
    {
        this.Init();
        initPos = this.transform.position;
    }


    private void Update()
    {
        this.onUpdate();
    }
    public override void onUpdate()
    {
        if (this.dead == true)
        {
            return;
        }

        /***鼠标输入 
        if (game.Status == Game.GAME_STATUS.Game)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("first" + this.transform.position.y);
                initY = this.transform.position.y;
                rigidbodyBrid.velocity = Vector2.zero;
                Vector2 froce = new Vector2(0, Force);
                rigidbodyBrid.AddForce(froce, ForceMode2D.Impulse);
                this.Fly(froce.y);
                Debug.Log("second" + this.transform.position.y);
            }
        }
        ***/


        Vector2 pos = this.transform.position;
        pos.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        pos.y += Input.GetAxis("Vertical") * Time.deltaTime * speed;
        this.transform.position = pos;
        fireTimer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            //Fire(this.bulletTemple); 
        }

    }


    // player的状态方法
    public void Init()
    {
        this.transform.position = initPos;
        this.dead = false;
        this.HP = 100;
        this.Idle();
 
    }




    public void Dead()
    {
        this.dead = true;
        if (rigidbodyBrid.bodyType == RigidbodyType2D.Kinematic)
            rigidbodyBrid.bodyType = RigidbodyType2D.Dynamic;
        // 死亡时下落
        playerAnimation.DownFly();

        // 触发函数
        if (this.OnDeath != null)
        {
            // 执行订阅函数
            this.OnDeath();
        }

    }


    // pleyer的刚体方法
    public void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(gameObject.name + " triggered with " + col.gameObject.name);
        Bullet bullet = col.gameObject.GetComponent<Bullet>();
        Enemy enemy = col.gameObject.GetComponent<Enemy>();
        //if (col.gameObject.name.Equals("ScoreArea"))
        //{

        //}
        if (col.gameObject.name.Equals("Ground"))
        {
            this.Dead();
        }
        if (bullet != null &&  bullet.side == SIDE.ENEMY)
        {
            if (this.HP > 0f)
            {
                if (this.onHP != null)
                {
                    // 触发订阅活动
                    this.onHP(50f);
                    this.HP -= 50f;
                }
            }
            else
            {
                this.Dead();
            }
        }

        if (enemy!=null)
        {
            this.HP = 0;
            this.Dead();
        }

        // 名字方式触发
        //    if (col.gameObject.name.Equals("Bullet(Clone)"))
        //{
        //    Debug.Log("my bullet");
        //}


    }


    void OnCollisionEnter(Collision col)
    {
        Debug.Log(gameObject.name + " collided with " + col.gameObject.name);
        this.Dead();

    }


    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log( gameObject.name  + " triggerred exit " + collision.gameObject.name);
        if (collision.gameObject.name.Equals("ScoreArea"))
        {
            // 触发起点
            if (this.onScore != null)
            {
                // 触发订阅活动
                this.onScore(1);
            }
        }
        else if (collision.gameObject.name.Equals("Ground"))
        {
            if (rigidbodyBrid.bodyType == RigidbodyType2D.Dynamic)
                rigidbodyBrid.bodyType = RigidbodyType2D.Kinematic;
        }
    }






}
