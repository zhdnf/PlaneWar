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

public class Player : MonoBehaviour
{
    // player刚体
    public Rigidbody2D rigidbodyBrid;

    // 记录游戏开始的初始位置
    private Vector3 initPos;

    // 相对位置做状态转换动画
    private float initY;
    public PlayerAnimation playerAnimation;

    public Game game;


    // 记录死亡状态
    public bool dead = false;
    // 死亡委托
    public delegate void DeathModify();
    public event DeathModify OnDeath;
  

    // 分数委托
    public UnityAction<int> onScore;


    public GameObject bulletTemple;

    //test
    public float Force = 5f;
    public float speed = 1f;
    public float fireRate = 10f;
    public float fireTimer = 0f;



    void Start()
    {   
        initPos = this.transform.position;
    }

    void Update()
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
            Fire();
        }
        
    }


    // 开火
    public void Fire()
    {
        if(fireTimer > 1f / fireRate)
        {
            GameObject firePos = Instantiate(bulletTemple);
            firePos.transform.position = this.transform.position;
            fireTimer = 0;
        }

    }




    // player的状态方法
    public void Init()
    {
        this.transform.position = initPos;
        this.dead = false;
        this.Idle();
    }

   
    public void Idle()
    {
        this.rigidbodyBrid.simulated = false;
        playerAnimation.Idle();
    }

    // 飞行状态根据y来切换飞行的状态（水平， 向上， 向下）
    public void Fly(float y)
    {
        this.rigidbodyBrid.simulated = true;

        // 1.2暂设为阈值
        if (y > 2*this.initY)
        {
            playerAnimation.UpFly();
        }
        else if (y < 2*this.initY)
        {
            playerAnimation.DownFly();
        }
        else
        {
            playerAnimation.LevelFly();
        }
    }

    public void Dead()
    {
        this.dead = true;
        if(rigidbodyBrid.bodyType == RigidbodyType2D.Kinematic)
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
        Debug.Log( gameObject.name + " triggered with " + col.gameObject.name);
        if (col.gameObject.name.Equals("ScoreArea"))
        {
           
        }
        else
        { 
            this.Dead();
        }

    }


    void OnCollisionEnter(Collision col)
    {
        Debug.Log(gameObject.name + " collided with " + col.gameObject.name);

        // 触发函数起点
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
        else if (collision.gameObject.name.Equals("Ground")){
            if (rigidbodyBrid.bodyType == RigidbodyType2D.Dynamic)
                rigidbodyBrid.bodyType = RigidbodyType2D.Kinematic;
        }
    }





}
