using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
*/

/// <summary>
///
/// </summary>

public class MyUI : Singleton<MyUI>
{

    public GameObject panelReady;
    public GameObject panelGame;
    public GameObject panelGameOver;

    public UIScore scoreObject;
    public Hp hpObject;


    public void UpdateUI()
    {
        this.panelReady.SetActive(Game.Instance.Status == Game.GAME_STATUS.Ready);
        this.panelGame.SetActive(Game.Instance.Status == Game.GAME_STATUS.Game);
        this.panelGameOver.SetActive(Game.Instance.Status == Game.GAME_STATUS.GameOver);
    }

    public void Ready()
    {
        Game.Instance.Status = Game.GAME_STATUS.Ready;
    }
    

    // 注意函数名与Start一致
    public void GameStart()
    {
        Game.Instance.Status = Game.GAME_STATUS.Game;
        hpObject.Init();
    }


    public void ReStart()
    {
        Game.Instance.Status = Game.GAME_STATUS.Ready;
        scoreObject.Init();
    }

    public void GameOver()
    {
        Game.Instance.Status = Game.GAME_STATUS.GameOver;
        hpObject.SetActive(false);
    }

    //HP与其交互
    public void OnPlayerHp(float damage)
    {
        hpObject.HP -= damage;
    }


    // 问题：放在其他Score类，执行错误
    // player的被委托事件  
    public void OnPlayerScore(int value)
    {
        scoreObject.Score += value;
        Debug.Log("Score" + scoreObject.Score);
    }

}
