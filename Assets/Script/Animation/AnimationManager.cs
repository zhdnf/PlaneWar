using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class AnimationManager : Singleton<AnimationManager>
{
    public PlayerAnimation player;
    public BossAnimation boss;
    public GroundAnimation ground;
    public EnemyAnimation enemy;

    private void Start()
    {
       
    }

    public void AnimationAction(string name, string action)
    {
        switch (name)
        {
            case "player":
                player.Action(action);
                break;
            case "boss":
                boss.Action(action);
                break;
            case "enemy":
                enemy.Action(action);
                break;
            case "ground":
                ground.Action(action);
                break;
            default:
                Debug.LogError("Animation Error");
                return;
        }
    }


}
