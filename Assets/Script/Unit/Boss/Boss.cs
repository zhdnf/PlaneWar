using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class Boss : Enemy
{
    public GameObject missileTemplate;

    BossAnimation bossAnimation;

    //机枪
    public Transform firePoint1;
    //炮台子弹
    public Transform firePoint2;
    //导弹
    public Transform firePoint3;

    //炮台
    public Transform Cannan;

    //炮台速率
    public float fireRate2 = 10f;
    float fireTimer2 = 0;

    //导弹cd
    public float UltCD = 10f;
    float fireTimer3 = 0;


    Missile missile = null;

    // Boss目标
    public Unit target;

    public override void Fly()
    { 
        return;
    }

    private void Start()
    {
        this.onStart();
    }

    public override void onStart()
    {
        StartCoroutine(Enter());
    }
    private void Update()
    {
        onUpdate();

        //this.onUpdate();
    }

    public override void onUpdate()
    {
        if (target != null)
        {
            Vector3 dir = (target.transform.position - Cannan.position).normalized;
            Cannan.transform.rotation = Quaternion.FromToRotation(Vector3.left, dir);
        }
    }


    IEnumerator Enter()
    {
        this.transform.position = new Vector3(15, 0, 0);
        yield return MoveTo(new Vector3(5, 0, 0));
        yield return Attack();
    }

    IEnumerator Attack()
    {
        while (true)
        {
            fireTimer2 += Time.deltaTime;
            Fire(bulletTemple, 30);
            Fire2();

            fireTimer3 += Time.deltaTime;
            if (fireTimer3 > UltCD)
            {
                yield return UltraAttack();
                fireTimer3 = 0;
            }
            yield return null;
        }

    }

    IEnumerator UltraAttack()
    {
        yield return MoveTo(new Vector3(5, 5, 0));
        yield return FireMissile();
        yield return MoveTo(new Vector3(5, 0, 0));
    }


    IEnumerator MoveTo(Vector3 pos)
    {
        while (true)
        {

            Vector3 dir = (target.transform.position - this.transform.position).normalized;
            if (dir.magnitude <  1 )
            {
                break;
            }
            this.transform.position += speed * dir * Time.deltaTime;
            yield return null; 

        }
    }


    IEnumerator FireMissile()
    {
        while (true)
        {
            //动画事件完成导弹发射
            bossAnimation.Launch();
            yield return new WaitForSeconds(5f);
        }

    }

    void Fire2()
    {
        while (fireTimer2 > 1f / fireRate2)
        {
            GameObject go = Instantiate(this.bulletTemple, firePoint2.position, Cannan.rotation);
            Bullet bullet = go.GetComponent<Bullet>();
            bullet.direction = (target.transform.position - firePoint2.position).normalized;
            fireTimer2 = 0f;
        }
    }

    public override void Fire(GameObject temple, float power)
    {
        fireTimer += Time.deltaTime;
        if (fireTimer > 1f / fireRate)
        {
            GameObject bullet = Instantiate(temple);
            bullet.GetComponent<Bullet>().direction = Vector3.left;
            // 代码是线子弹变颜色
            //SpriteRenderer[] sprs = firePos.GetComponents<SpriteRenderer>();
            //for(int i = 0; i<sprs.Length; i++)
            //{
            //    sprs[i].color = Color.red;
            //}
            bullet.transform.position = firePoint1.position;
            fireTimer = 0;
        }
    }


    public void OnMissileLoad()
    {
        GameObject go = Instantiate(missileTemplate, this.firePoint3);
        missile = go.GetComponent<Missile>();
        missile.target = this.target.transform;
    }

    public void OnMissileLaunch()
    {
        if(missile == null)
        {
            return;
        }
        missile.Launch();
    }

    public override void OnCollisionEnter(Collision col)
    {
        Debug.Log("Enemy:OnCollisionEnter2D : " + col.gameObject.name + " : " + gameObject.name + " : " + Time.time);

    }


    public override void OnTriggerEnter2D(Collider2D col)
    {
        Bullet bullet = col.gameObject.GetComponent<Bullet>();
        if (bullet == null)
        {
            return;
        }
        Debug.Log("Enemy:OnTriggerEnter2D : " + col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if (bullet.side == SIDE.PLAYER)
        {
            this.Damage(bullet.power);
        }
    }


}
