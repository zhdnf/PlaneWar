using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
*/

/// <summary>
///
/// </summary>

public class Enemy : MonoBehaviour
{
    // player刚体
    public Rigidbody2D rigidbodyBrid;


    // 相对位置做状态转换动画
    private float initY;
    public PlayerAnimation playerAnimation;


    // 记录死亡状态
    public bool dead = false;
    // 死亡委托
    public delegate void DeathModify();
    public event DeathModify OnDeath;

    public GameObject bulletTemple;

    public float minRange = -3;
    public float maxRange = 3;

    //test
    public float Force = 5f;
    public float speed = 5f;
    public float fireRate = 10f;
    public float fireTimer = 0f;
    public float destoryTimer = 0f;



    void Start()
    {
        this.Init();
    }

    void Update()
    {
        // if (this.dead == true)
        initY = this.transform.position.y;
        destoryTimer += Time.deltaTime;
        if(destoryTimer > 6)
        {
            Destroy(this.gameObject);
        }
        this.transform.position += new Vector3(-1 * Time.deltaTime * speed, 0, 0);
        fireTimer += Time.deltaTime;
        Fire();


    }


    // 开火
    public void Fire()
    {
        if (fireTimer > 1f / fireRate)
        {
            GameObject firePos = Instantiate(bulletTemple);
            firePos.GetComponent<Bullet>().direction = -1;
            // 代码是线子弹变颜色
            //SpriteRenderer[] sprs = firePos.GetComponents<SpriteRenderer>();
            //for(int i = 0; i<sprs.Length; i++)
            //{
            //    sprs[i].color = Color.red;
            //}
            firePos.transform.position = this.transform.position;
            fireTimer = 0;
        }

    }




    // player的状态方法
    public void Init()
    {
        this.dead = false;
        //this.Idle();
        this.Fly(this.transform.position.y);
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
        if (y > 2 * this.initY)
        {
            playerAnimation.UpFly();
        }
        else if (y < 2 * this.initY)
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

        if (rigidbodyBrid.bodyType == RigidbodyType2D.Kinematic)
            rigidbodyBrid.bodyType = RigidbodyType2D.Dynamic;
        
        // 死亡时下落(暂替死亡动画)
        playerAnimation.DownFly();
        


        // 触发函数
        if (this.OnDeath != null)
        {
            // 执行订阅函数
            this.OnDeath();
        }

        Destroy(this.gameObject, 0.1f);
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(gameObject.name + " triggered with " + col.gameObject.name);
 
        if (col.gameObject.name.Equals("EnemyBullet(Clone)"))
        {
            Debug.Log("Enemy's bullet");
        }
        else if (col.gameObject.name.Equals("ScoreArea"))
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
        Bullet bullet = col.gameObject.GetComponent<Bullet>();
        if (bullet == null)
        {
            return;
        }
        if (bullet.side == SIDE.PLAYER)
        {
            this.Dead();
        }
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

}
