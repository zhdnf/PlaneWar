using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class GroundAnimation : MonoBehaviour
{
    public Animator groundAnimator;

    public void Static()
    {
        this.groundAnimator.SetTrigger("static");
    }

    public void Active()
    {
        this.groundAnimator.SetTrigger("active");
    }
}
