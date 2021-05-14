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
    private void Update()
    {
        this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        if (Screen.safeArea.Contains(Camera.main.WorldToScreenPoint(this.transform.position)) == false)
        {
            Destroy(this.gameObject, 1f);
        }
    }
}
