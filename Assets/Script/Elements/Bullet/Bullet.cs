using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class Bullet : MonoBehaviour
{
    public float speed;

    public SIDE side;

    // 1 向右 0向左
    public int direction = 1;   
    
    private void Update()
    {
        this.transform.position += new Vector3(speed * Time.deltaTime * direction, 0, 0);

        // 子弹在屏幕外就删除
        if (Screen.safeArea.Contains(Camera.main.WorldToScreenPoint(this.transform.position)) == false)
        {
            Destroy(this.gameObject, 1f);
        }
    }
}
