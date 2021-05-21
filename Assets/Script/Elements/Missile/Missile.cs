using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class Missile : Bullet
{
    public Transform target;

    public GameObject fxExplode;

    public bool running = false;

    //爆炸距离
    public float distance = 0.1f;

    private void Start()
    {
        target = UnitManager.Instance.player.transform;
        this.power = 20f;
        this.speed = 10f;
            
    }

    private void Update()
    {
        this.onUpdate();
    }
    public override void onUpdate()
    {
        if(running == false)
        {
            return;
        }
        if (target != null)
        {
            // 两点成的向量
            Vector3 vector = (target.position - this.transform.position);
            // 方向向量
            Vector3 dir = vector.normalized;

            if(vector.magnitude < distance)
            {
                this.Explode();
            }

            //旋转角度
            this.transform.rotation = Quaternion.FromToRotation(Vector3.left, dir);
            //向目标前进
            this.transform.position += speed * dir * Time.deltaTime;

        }
    }

    public void Launch()
    {
        running = true;
    }

    public void Explode()
    {
        Destroy(this.gameObject,0.2f);
        Instantiate(fxExplode, this.transform.position, Quaternion.identity);
    }
}
