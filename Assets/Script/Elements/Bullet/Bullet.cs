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

    public float power = 2f;


    private void Update()
    {
        this.onUpdate();
    }
    public override void onUpdate()
    {
        this.transform.position += speed * this.direction * Time.deltaTime;
        // 子弹在屏幕外就删除
        if (Screen.safeArea.Contains(Camera.main.WorldToScreenPoint(this.transform.position)) == false)
        {
            Destroy(this.gameObject, 1f);
        }
    }
}
