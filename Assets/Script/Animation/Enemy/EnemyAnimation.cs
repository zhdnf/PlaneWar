using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class EnemyAnimation : MonoBehaviour 
{ 

    public Animator enemyAnimator;

    public void Action(string action)
    {
        switch (action)
        {
            //case "idle":
            //    this.Idle();
            //    break;
            case "dead":
                this.Dead();
                break;
            default:
                Debug.LogError("action is error");
                return;
        }
    }

    private void Start()
    {
        
    }

    //public void Idle()
    //{
    //    this.enemyAnimator.SetTrigger("idle");
    //}

    public void Dead()
    {
        this.enemyAnimator.SetTrigger("dead");
    }
}
