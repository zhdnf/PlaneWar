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
    public GameObject panelAtomic;
    public GameObject UIAnimation;
    public GameObject levelName;
    public GameObject panelGold;

    public UIScore scoreObject;
    public GoldUI goldObject;
    public AtomicUI atomicObject;
    public Hp player;
    public Hp boss;


    public void UpdateUI()
    {
        this.panelReady.SetActive(Game.Instance.Status == Game.GAME_STATUS.Ready);
        this.panelGame.SetActive(Game.Instance.Status == Game.GAME_STATUS.Game);
        this.panelGold.SetActive(Game.Instance.Status == Game.GAME_STATUS.Game);
        this.panelAtomic.SetActive(Game.Instance.Status == Game.GAME_STATUS.Game);
        this.UIAnimation.SetActive(Game.Instance.Status == Game.GAME_STATUS.Game || Game.Instance.Status == Game.GAME_STATUS.GameOver);
        this.panelGameOver.SetActive(Game.Instance.Status == Game.GAME_STATUS.GameOver);
        this.levelName.SetActive(Game.Instance.Status == Game.GAME_STATUS.Game);
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
        boss.SetActive(false);
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
        boss.SetActive(false);
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

    // player的被委托事件  
    public void OnScore(int value)
    {
        scoreObject.Score += value;
        Debug.Log("Score" + scoreObject.Score);
    }

    public void OnGold(int value)
    {
        goldObject.Nums += value;
        Debug.Log("Gold" + scoreObject.Score);
    }

    public void OnAtomicUse()
    {
        atomicObject.OnAtomicUse();
    }


    public void BossInitHp(float hp, bool active)
    {
        boss.Init(hp);
        boss.SetActive(active);
    }

    public void ShowLevelName()
    {
        int currentId = LevelManager.Instance.currentLevelID;
        levelName.GetComponentInChildren<Text>().text = string.Format("LEVEL  {0}", currentId.ToString());
    }
}
