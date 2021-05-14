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

    public void Idle()
    {
        this.playerAnimator.SetTrigger("idle");
    }

    public void LevelFly()
    {
        this.playerAnimator.SetTrigger("level_fly");
    }

    public void UpFly()
    {
        this.playerAnimator.SetTrigger("up_fly");
    }

    public void DownFly()
    {
        this.playerAnimator.SetTrigger("down_fly");
    }

}
