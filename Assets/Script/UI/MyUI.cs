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
    public GameObject UIAnimation;

    public UIScore scoreObject;
    public Hp player;
    public Hp boss;


    public void UpdateUI()
    {
        this.panelReady.SetActive(Game.Instance.Status == Game.GAME_STATUS.Ready);
        this.panelGame.SetActive(Game.Instance.Status == Game.GAME_STATUS.Game);
        this.UIAnimation.SetActive(Game.Instance.Status == Game.GAME_STATUS.Game || Game.Instance.Status == Game.GAME_STATUS.GameOver);
        this.panelGameOver.SetActive(Game.Instance.Status == Game.GAME_STATUS.GameOver);

    }

    public void Ready()
    {
        Game.Instance.Status = Game.GAME_STATUS.Ready;
        player.SetActive(false);
        boss.SetActive(false);
    }
    

    // 注意函数名与Start一致
    public void GameStart()
    {
        Game.Instance.Status = Game.GAME_STATUS.Game;
        player.Init(100f);
    }


    public void ReStart()
    {
        Game.Instance.Status = Game.GAME_STATUS.Ready;
        scoreObject.Init();
    }

    public void GameOver()
    {
        Game.Instance.Status = Game.GAME_STATUS.GameOver;
        player.SetActive(false);
    }

    //HP与其交互
    public void HpUpdate(Bullet bullet)
    {
        switch(bullet.side)
        {
            case SIDE.ENEMY:
                player.HP -= bullet.power;
                break;
            case SIDE.PLAYER:
                boss.HP -= bullet.power;
                break;
            default:
                Debug.LogError("bullet's Side Error");
                return;
        }
    }


    // 问题：放在其他Score类，执行错误
    // player的被委托事件  
    public void OnPlayerScore(int value)
    {
        scoreObject.Score += value;
        Debug.Log("Score" + scoreObject.Score);
    }

   
    public void BossInitHp(float hp, bool active)
    {
        boss.Init(hp);
        boss.SetActive(active);
    }
}
