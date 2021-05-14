using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
*/

/// <summary>
///
/// </summary>

public class Game : MonoBehaviour
{
    public enum GAME_STATUS{
        Ready, 
        Game, 
        GameOver
    };

    private GAME_STATUS status;

    public GAME_STATUS Status
    {
        get { return status;  }
        set { 
                this.status = value;
            }
    }


    public PipeLineManager pipeManager;

    public Player player;

    public GroundAnimation ground;

    public MyUI ui;
    public UIScore score;


    void Start()
    {
        ui.Init();
        player.Idle();
        ground.Static();
        Debug.Log(this.status);

        // 添加分数委托
        player.onScore += OnPlayerScore;
        
        // 添加死亡委托
        player.OnDeath += Player_onDeath;

        
    }

    void Update()
    {

    }

    private void Player_onDeath()
    {
        this.Status = GAME_STATUS.GameOver;
        ui.GameOver();
        ground.Static();
        this.pipeManager.PipeLineManagerStop();
    }

    // player的被委托事件
    public void OnPlayerScore(int value)
    {
        score.Score += value;
        Debug.Log("Score" + score.Score);
    }




    public void GameStart()
    {
        ui.GameStart();
        pipeManager.PipeLineManagerStart();
        Debug.LogFormat("StartGame: {0}", this.Status);
        ground.Active();
        player.Fly(0);
    }

    public void ReStart()
    {
        ui.ReStart();
        ground.Static();
        pipeManager.Init();
        player.Init();
    }
}
