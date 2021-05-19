using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class PlayerAnimation : MonoBehaviour
{

    public Animator playerAnimator;

    public void Action(string action)
    {
        switch (action)
        {
            case "idle":
                this.Idle();
                break;
            case "fly": 
                this.LevelFly();
                break;
            case "dead": 
                this.DownFly();
                break;
            default:
                Debug.LogError("action is error");
                return;
        }
    }

    private void Start()
    {
       
    }


    public void Idle()
    {
        this.playerAnimator.SetTrigger("idle");
    }

    public void LevelFly()
    {
        this.playerAnimator.SetTrigger("level_fly");
    }

    public void DownFly()
    {
        this.playerAnimator.SetTrigger("down_fly");
    }

}
