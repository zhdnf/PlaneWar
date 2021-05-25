using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
*/

/// <summary>
/// player交互相关的方法
/// </summary>

public class Player : Unit
{

    public Vector3 dircetion = Vector3.right;

    private float timer;

    // 金币数量
    public int goldNums;

    // 道具委托
    public delegate void ItemModify(Player sender);
    public event ItemModify OnItem;

    //test
    public float Force = 5f;



    private void Start()
    {
        this.onStart();
    }

    public override void onStart()
    {

        this.goldNums = 0;
        this.power = 100f;
        this.transform.position = initPos;
        this.death = false;
        this.HP = 100;
        this.power = 10;

        AnimationStrategy.Instance.Strategy = this.GetComponent<PlayerAnimation>();
        AnimationStrategy.Instance.Strategy.Action("idle");
    }


    private void Update()
    {
        this.onUpdate();
    }

    public override void onUpdate()
    {
        if (this.death)
        {
            return;
        }
        timer += Time.deltaTime;
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

        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            pos.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            pos.y += Input.GetAxis("Vertical") * Time.deltaTime * speed;

            pos = ViewPoint.Instance.PlayerMoveablePosition(pos, .1f, .1f);
        }
        this.transform.position = pos;






        if (Input.GetButton("Fire1")){
            Fire(this.bulletTemple, this.power);
        }
        
    }

    public void Init()
    {
        this.transform.position = initPos;
        this.Fly();
        this.death = false;
        this.HP = 100f;
    }



    public override void Idle()
    {
        this.rigidbodyBrid.simulated = true;
        AnimationStrategy.Instance.Strategy = this.GetComponent<PlayerAnimation>();
        AnimationStrategy.Instance.Strategy.Action("idle");
    }


    public override void Fly()
    {
        this.rigidbodyBrid.simulated = true;
        AnimationStrategy.Instance.Strategy = this.GetComponent<PlayerAnimation>();
        AnimationStrategy.Instance.Strategy.Action("fly");
    }


    public override void Dead()
    {
        base.Dead();
        AnimationStrategy.Instance.Strategy = this.GetComponent<PlayerAnimation>();
        AnimationStrategy.Instance.Strategy.Action("dead");
    }



    // pleyer的刚体方法
    public void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(gameObject.name + " triggered with " + col.gameObject.name);
        Bullet bullet = col.gameObject.GetComponent<Bullet>();
        Enemy enemy = col.gameObject.GetComponent<Enemy>();
        Item item = col.gameObject.GetComponent<Item>();
        //if (col.gameObject.name.Equals("ScoreArea"))
        //{

        //}
        if (col.gameObject.name.Equals("Ground"))
        {
            this.Dead();
        }

        if(item != null)
        {
            if(this.OnItem != null)
            {
                OnItem(this);
            }
        }


        if (bullet != null &&  bullet.side == SIDE.ENEMY)
        {
            if (this.HP > 0f)
            {
                if (this.onHP != null)
                {
                    // 触发订阅活动
                    this.onHP(bullet);
                    this.Damage(bullet.power);
                }
            }
            else
            {
                this.Dead();
            }
        }

        if (enemy != null)
        {
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
        Debug.Log(gameObject.name + " triggerred exit " + collision.gameObject.name);
        //if (collision.gameObject.name.Equals("ScoreArea"))
        //{
        //    // 触发起点
        //if (this.onScore != null)
        //{
        //    // 触发订阅活动
        //    this.onScore(1);
        //}
        //}
        if (collision.gameObject.name.Equals("Ground"))
        {
            if (rigidbodyBrid.bodyType == RigidbodyType2D.Dynamic)
                rigidbodyBrid.bodyType = RigidbodyType2D.Kinematic;
        }
    }






}
