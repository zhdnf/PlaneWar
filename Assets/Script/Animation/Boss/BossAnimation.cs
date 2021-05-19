using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class BossAnimation : MonoBehaviour, AnimationInterface
{
    public Animator boosAnimatior;

    public void Action(string action)
    {
        switch (action)
        {
            case "fly":
                this.Idle();
                break;
            case "launch":
                this.Launch();
                break;
            case "dead":
                this.Dead();
                break;
            default:
                Debug.LogError("action is error");
                return;
        }
    }

    public void Idle()
    {
        this.boosAnimatior.SetTrigger("idle");
    }


    public void Launch()
    {
        this.boosAnimatior.SetTrigger("Skill");
    }

    public void Dead()
    {
        this.boosAnimatior.SetTrigger("dead");
    }

}
