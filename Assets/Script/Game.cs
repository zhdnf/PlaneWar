﻿using System.Collections;
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
    public UnitManager unitManager;


    public Unit unit;



    public GroundAnimation ground;

    public MyUI ui;
    public UIScore score;
    public Hp hp;


    void Start()
    {

        ui.Init();
        ground.Static();

        Debug.Log(this.status);

        // 添加分数委托
        unitManager.player.onScore += OnPlayerScore;

        // 添加死亡委托
        unitManager.player.OnDeath += Player_onDeath;

        // 添加血量委托
        unitManager.player.onHP += OnPlayerHp;

        
    }

    void Update()
    {

    }

    private void Player_onDeath()
    {
        this.Status = GAME_STATUS.GameOver;
        ui.GameOver();
        ground.Static();
        pipeManager.PipeLineManagerStop();
        unitManager.EnemyManagerStop();
    }


    // 问题：放在其他Score类，执行错误
    // player的被委托事件  
    public void OnPlayerScore(int value)
    {
        score.Score += value;
        Debug.Log("Score" + score.Score);
    }

    public void OnPlayerHp(float damage)
    {
        hp.HP -= damage;
    }




    public void GameStart()
    {
        ui.GameStart();
        pipeManager.PipeLineManagerStart();
        unitManager.EnemyManagerStart();
        Debug.LogFormat("StartGame: {0}", this.Status);
        ground.Active();
        unitManager.player.Fly(0);
    }

    public void ReStart()
    {
        ui.ReStart();
        ground.Static();
        pipeManager.Init();
        unitManager.player.Init();
    }
}
