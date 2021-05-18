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

    //机枪
    public Transform firePoint1;
    //炮台子弹
    public Transform firePoint2;
    //导弹
    public Transform firePoint3;

    //炮台
    public Transform Cannan;

    Missile missile;
    public Unit target;

    public override void Fly(float y)
    {
        return;
    }

    private void Start()
    {
        this.onStart();
    }

    private void Update()
    {


        this.onUpdate();
    }

    public override void onStart()
    {
        StartCoroutine(Enter());
        StartCoroutine(Fire2());
        StartCoroutine(FireMissile());
        StartCoroutine(Attack());

    }

    IEnumerator Enter()
    {
        this.transform.position = new Vector3(15, 0, 0);
        yield return MoveTo(new Vector3(5, 0, 0));
        yield return null;
    }

    IEnumerator Attack()
    {
        while (true)
        {
            this.Fire(this.bulletTemple);
            yield return null;
        }

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
            this.transform.rotation = Quaternion.FromToRotation(Vector3.left, dir);
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

    IEnumerator Fire2()
    {
        while (true)
        {
            GameObject go = Instantiate(bulletTemple, firePoint2.position, Cannan.rotation);
            Elements bullet = go.GetComponent<Bullet>();
            bullet.direction = (target.transform.position - Cannan.position).normalized;
            this.transform.position += speed * bullet.direction;
            yield return new WaitForSeconds(5f);
        }
    }

    public override void Fire(GameObject temple)
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
            bullet.transform.position = firePoint1.position;
            fireTimer = 0;
        }
    }


    public override void onUpdate()
    {

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

}
