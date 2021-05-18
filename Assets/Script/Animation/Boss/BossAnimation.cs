using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class BossAnimation : MonoBehaviour
{
    public Animator boosAnimatior;

    public void Idle()
    {
        this.boosAnimatior.SetTrigger("idle");
    }


    public void Launch()
    {
        this.boosAnimatior.SetTrigger("Skill");
    }

}
