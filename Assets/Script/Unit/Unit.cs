using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class Unit : MonoBehaviour
{

    // 记录死亡状态
    public bool dead = false;

    // 对象刚体
    public Rigidbody2D rigidbodyBrid;

    // 记录游戏开始的初始位置
    protected Vector3 initPos;

    // 相对位置做状态转换动画
    protected float initY;
    public PlayerAnimation playerAnimation;
    public BossAnimation bossAnimation;

    // 绑定子弹
    public GameObject bulletTemple;


    // HP
    public float HP = 100f;
    public float maxHP = 100f;

    public float speed = 1f;
    public float fireRate = 10f;
    public float fireTimer = 0f;

    public virtual void onStart()
    {

    }

    public virtual void onUpdate()
    {
        
    }


    // 开火
    public virtual void Fire(GameObject temple)
    {
        fireTimer += Time.deltaTime;
        if (fireTimer > 1f / fireRate)
        {
            GameObject bullet = Instantiate(temple);
            this.BulletInit(bullet.GetComponent<Bullet>());
            // 代码是线子弹变颜色
            //SpriteRenderer[] sprs = firePos.GetComponents<SpriteRenderer>();
            //for(int i = 0; i<sprs.Length; i++)
            //{
            //    sprs[i].color = Color.red;
            //}
            bullet.transform.position = this.transform.position;
            fireTimer = 0;
        }
    }

    protected virtual void BulletInit(Bullet bullet)
    {
        bullet.direction = Vector3.right;
    }



    // 角色状态
    public void Idle()
    {
        this.rigidbodyBrid.simulated = false;
        playerAnimation.Idle();
    }

    // 飞行状态根据y来切换飞行的状态（水平， 向上， 向下）
    public virtual void Fly(float y)
    {
        this.rigidbodyBrid.simulated = true;
        playerAnimation.LevelFly();

        //// 1.2暂设为阈值
        //if (y > 2 * this.initY)
        //{
        //    playerAnimation.UpFly();
        //}
        //else if (y < 2 * this.initY)
        //{
        //    playerAnimation.DownFly();
        //}
        //else
        //{
        //    playerAnimation.LevelFly();
        //}
    }

    public void Damgage(float power)
    {
        this.HP -= power;
    }
}
