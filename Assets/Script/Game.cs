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

        AnimationStrategy.Instance.Strategy = this.GetComponentInChildren<GroundAnimation>();
        AnimationStrategy.Instance.Strategy.Action("static");

        MyUI.Instance.Ready();

        // 添加分数委托
        player.onScore += MyUI.Instance.OnPlayerScore;

        // 添加死亡委托
        player.OnDeath += Player_onDeath;

        // 添加血量委托
        player.onHP += MyUI.Instance.HpUpdate;

        //Level level1 = Resources.Load<Level>("Level1");
        //Level level2 = Resources.Load<Level>("Level2");

     

    }

    void Update()
    {

    }

    private void Player_onDeath(Unit unit)
    {
        
        if (player.HP <= 0)
        {
            UnitManager.Instance.Clear();
        }
        this.Status = GAME_STATUS.GameOver;
        MyUI.Instance.GameOver();
        AnimationStrategy.Instance.Strategy = this.GetComponentInChildren<GroundAnimation>();
        AnimationStrategy.Instance.Strategy.Action("static");
        pipeManager.PipeLineManagerStop();
        // UnitManager.Instance.EnemyManagerStop();
        StopAllCoroutines();
    }


    public void GameStart()
    {

        MyUI.Instance.GameStart();
        AnimationStrategy.Instance.Strategy = this.GetComponentInChildren<UIAnimation>();
        AnimationStrategy.Instance.Strategy.Action("start");
        this.player.Fly();
        LoadLevel();
        pipeManager.PipeLineManagerStart();
        // UnitManager.Instance.EnemyManagerStart();
        AnimationStrategy.Instance.Strategy = this.GetComponentInChildren<GroundAnimation>();
        AnimationStrategy.Instance.Strategy.Action("active");
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
            player.HP = 0;
            MyUI.Instance.GameOver();
            AnimationStrategy.Instance.Strategy = this.GetComponentInChildren<UIAnimation>();
            AnimationStrategy.Instance.Strategy.Action("end");
            StopAllCoroutines();
            //this.currentLevelID++;
            //LoadLevel();
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
        AnimationStrategy.Instance.Strategy = this.GetComponentInChildren<GroundAnimation>();
        AnimationStrategy.Instance.Strategy.Action("static");
        pipeManager.Init();
    }

    public void PlayerInit()
    {
        this.player.Init();
    }
}
