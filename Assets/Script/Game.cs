using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        Utility.Instance.Animation(this.GetComponentInChildren<GroundAnimation>(), "static");

        MyUI.Instance.Ready();

        //// 添加分数委托
        //player.onScore += MyUI.Instance.OnScore;

        // 添加死亡委托
        player.OnDeath += Player_onDeath;

        // 添加血量委托
        player.onHP += MyUI.Instance.HpUpdate;

        this.PlayerInit();

        //Level level1 = Resources.Load<Level>("Level1");
        //Level level2 = Resources.Load<Level>("Level2");

    }


    void Update()
    {
        Global.levelRunTime += Time.deltaTime;
    }

    private void Player_onDeath(Unit unit)
    {
        Global.levelRunTime = 0;
        if (player.HP <= 0)
        {
            UnitManager.Instance.Clear();
        }
        this.Status = GAME_STATUS.GameOver;
        MyUI.Instance.GameOver();
        Utility.Instance.Animation(this.GetComponentInChildren<GroundAnimation>(), "static");
        pipeManager.PipeLineManagerStop();
        // UnitManager.Instance.EnemyManagerStop();
        StopAllCoroutines();
        //this.GameOver();
    }


    public void GameStart()
    {
        Global.levelRunTime = 0;
        MyUI.Instance.GameStart();
        Utility.Instance.Animation(this.GetComponentInChildren<UIAnimation>(), "start");
        this.player.Fly();
        LoadLevel();
        MyUI.Instance.ShowLevelName();
        pipeManager.PipeLineManagerStart();
        // UnitManager.Instance.EnemyManagerStart();
        Utility.Instance.Animation(this.GetComponentInChildren<GroundAnimation>(),"active");

    }

    private void LoadLevel()
    {
        LevelManager.Instance.LoadLevel(this.currentLevelID );
        LevelManager.Instance.level.OnLevelEnd = OnLevelEnd;
    }

    void OnLevelEnd(Level.LEVEL_RESULT result)
    {
        if(result == Level.LEVEL_RESULT.SUCCESS)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Global.levelRunTime = 0;
            this.currentLevelID++;
            if (this.currentLevelID > 2)
            {
                this.GameOver();
            }
            else
            {
                LoadLevel();
                MyUI.Instance.ShowLevelName();
                Utility.Instance.Animation(this.GetComponentInChildren<UIAnimation>(), "start");
            }

        }
        else
        {
            MyUI.Instance.GameOver();
            Utility.Instance.Animation(this.GetComponentInChildren<UIAnimation>(), "end");
            StopAllCoroutines();
        }

    }

    public void ReStart()
    {
        Application.LoadLevel(1);
        PlayerInit();
        //MyUI.Instance.ReStart();
        //Utility.Instance.Animation(this.GetComponentInChildren<GroundAnimation>(), "static");
        //pipeManager.Init();
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayerInit()
    {
        this.player.Init();
    }
}
