using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class AnimationStrategy : Singleton<AnimationStrategy>
{
    AnimationInterface strategy;
    public AnimationInterface Strategy
    {
        get { return this.strategy; }
        set { this.strategy = value; }
        
    }

    public void Action(string action)
    {
        this.strategy.Action(action);
    }

    private void Start()
    {

    }
}
