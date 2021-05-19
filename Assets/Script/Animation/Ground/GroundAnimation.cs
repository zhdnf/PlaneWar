using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class GroundAnimation : MonoBehaviour, AnimationInterface
{
    public Animator groundAnimator;

    public void Action(string action)
    {
        switch (action)
        {
            case "static":
                this.Static();
                break;
            case "active":
                this.Active();
                break;
            default:
                Debug.LogError("action is error");
                return;
        }
    }

    public void Static()
    {
        this.groundAnimator.SetTrigger("static");
    }

    public void Active()
    {
        this.groundAnimator.SetTrigger("active");
    }
}
