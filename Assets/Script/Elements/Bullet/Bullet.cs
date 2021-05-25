using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class Bullet : Elements
{

    public BULLETTYPE bulletType = BULLETTYPE.NORMAL;

    public GameObject fxExplode;

    public float speed;

    public Vector3 direction = Vector3.zero;

    public SIDE side;

    public float power = 1;

    public float lifeTime = 1f;

    public float timer = 0;

    private void Start()
    {
        this.onStart();
    }


    public override void onStart()
    {
        Destroy(this.gameObject, lifeTime);
    }

    private void Update()
    {
        this.onUpdate();
    }
    public override void onUpdate()
    {
        this.transform.position += speed * Time.deltaTime * direction;
        timer += Time.deltaTime;
        if (bulletType == BULLETTYPE.ATOMIC && timer>=(lifeTime - 0.2f))
        {
            Instantiate(fxExplode, transform.position, Quaternion.identity);
        }

        //if (!Utility.Instance.InScreen(this.transform.position))
        //{
        //    Destroy(this.gameObject, 1f);
        //}
    }

}
