using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
*/

/// <summary>
///
/// </summary>

public class Unit : MonoBehaviour
{



    // 对象刚体
    public Rigidbody2D rigidbodyBrid;


    // 记录游戏开始的初始位置
    protected Vector3 initPos;

    // 死亡委托
    public delegate void DeathModify(Unit sender);
    public event DeathModify OnDeath;

    // 分数委托
    public UnityAction<int> onScore;
    // 血量委托
    public UnityAction<float> onHP;


    //// 相对位置做状态转换动画
    //protected float initY;


    // 记录死亡状态
    public bool death = false;
    // 死亡时是否消除对象
    public bool destoryOnDeath = false;

    // 子弹伤害
    public float power;
    // 绑定子弹
    public GameObject bulletTemple;
    // 子弹速率
    public float fireRate = 10f;
    /// 和子弹间隔
    public float fireTimer = 0f;

    // HP
    private float hp = 100f;
    public float HP 
    {
        get{return this.hp; }
        set { this.hp = value; }
    }
    public float maxHP = 100f;

    // 速度
    public float speed = 1f;


    private void Start()
    {
        
    }

    public virtual void onStart()
    {

    }

    private void Update()
    {
        
    }
    public virtual void onUpdate()
    {
        
    }


    // 开火
    public virtual void Fire(GameObject temple, float power)
    {
        fireTimer += Time.deltaTime;
        if (fireTimer > 1f / fireRate)
        {
            GameObject bullet = Instantiate(temple);
            //this.BulletInit(bullet.GetComponent<Bullet>());
            // 代码是线子弹变颜色
            //SpriteRenderer[] sprs = firePos.GetComponents<SpriteRenderer>();
            //for(int i = 0; i<sprs.Length; i++)
            //{
            //    sprs[i].color = Color.red;
            //}
            bullet.GetComponent<Bullet>().power = power;
            bullet.transform.position = this.transform.position;
            fireTimer = 0;
        }
    }

    protected virtual void BulletInit(Bullet bullet)
    {
        bullet.direction = Vector3.right;
    }



    // 角色状态
    public virtual void Idle()
    {

    }

    public virtual void Fly()
    {

    }

    public virtual void Dead()
    {
        if (death)
        {
            return;
        }

        this.hp = 0;
        this.death = true;
        //Utility.Instance.GravitySwitch(this.rigidbodyBrid);
        //// 死亡时下落
        //playerAnimation.DownFly();
        // 触发函数
        if (this.OnDeath != null)
        {
            // 执行订阅函数
            this.OnDeath(this);
        }

        if (destoryOnDeath)
            Destroy(this.gameObject, 0.2f);

    }

    public void Damage(float power)
    {
        this.hp -= power;
        if(this.HP <= 0)
        {
            this.Dead();
        }
    }
}
