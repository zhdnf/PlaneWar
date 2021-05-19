using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
*/

/// <summary>
///
/// </summary>

public class Game : Singleton<Game>
{
    public Player player;

    public int currentLevelID = 1;

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
                MyUI.Instance.UpdateUI();
            }
    }

    public PipeLineManager pipeManager;

    void Start()
    {
        
        MyUI.Instance.Ready();
        AnimationManager.Instance.AnimationAction("ground", "static");


        // 添加分数委托
        player.onScore += MyUI.Instance.OnPlayerScore;

        // 添加死亡委托
        player.OnDeath += Player_onDeath;

        // 添加血量委托
        player.onHP += MyUI.Instance.OnPlayerHp;

        //Level level1 = Resources.Load<Level>("Level1");
        //Level level2 = Resources.Load<Level>("Level2");

     

    }

    void Update()
    {

    }

    private void Player_onDeath(Unit unit)
    {
        this.Status = GAME_STATUS.GameOver;
        MyUI.Instance.GameOver();
        AnimationManager.Instance.AnimationAction("ground", "static");
        pipeManager.PipeLineManagerStop();
        // UnitManager.Instance.EnemyManagerStop();
    }


    public void GameStart()
    {
        MyUI.Instance.GameStart();
        this.player.Fly();
        LoadLevel();
        pipeManager.PipeLineManagerStart();
        // UnitManager.Instance.EnemyManagerStart();
        AnimationManager.Instance.AnimationAction("ground", "active");
    }

    private void LoadLevel()
    {
        LevelManager.Instance.LoadLevel(this.currentLevelID);
        LevelManager.Instance.level.OnLevelEnd = OnLevelEnd;
    }

    void OnLevelEnd(Level.LEVEL_RESULT result)
    {
        if(result == Level.LEVEL_RESULT.SUCCESS)
        {
            this.currentLevelID++;
            LoadLevel();
        }
        else
        {
            MyUI.Instance.GameOver();
        }

    }

    public void ReStart()
    {
        PlayerInit();
        MyUI.Instance.ReStart();
        AnimationManager.Instance.AnimationAction("ground", "static");
        pipeManager.Init();
    }

    public void PlayerInit()
    {
        this.player.Init();
    }
}
