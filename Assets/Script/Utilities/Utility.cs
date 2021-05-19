using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class Utility : Singleton<Utility>
{
    public bool InScreen(Vector3 pos)
    {
        return Screen.safeArea.Contains(Camera.main.WorldToScreenPoint(pos));
    }

    public void GravitySwitch(Rigidbody2D obj)
    {
        if (obj.bodyType == RigidbodyType2D.Kinematic)
        {
            obj.bodyType = RigidbodyType2D.Dynamic;
        }
        else
        {
            obj.bodyType = RigidbodyType2D.Kinematic;
        }
    }

}
