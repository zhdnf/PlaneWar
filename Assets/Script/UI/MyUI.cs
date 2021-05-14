using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
*/

/// <summary>
///
/// </summary>

public class MyUI : MonoBehaviour
{

    public GameObject panelReady;
    public GameObject panelGame;
    public GameObject panelGameOver;

    public Game game;
    public UIScore score;


    public void UpdateUI()
    {
        this.panelReady.SetActive(game.Status == Game.GAME_STATUS.Ready);
        this.panelGame.SetActive(game.Status == Game.GAME_STATUS.Game);
        this.panelGameOver.SetActive(game.Status == Game.GAME_STATUS.GameOver);
    }

    public void Init()
    {
        game.Status = Game.GAME_STATUS.Ready;
        UpdateUI();
    }
    

    // 注意函数名与Start一致
    public void GameStart()
    {
        game.Status = Game.GAME_STATUS.Game;
        UpdateUI();
    }


    public void ReStart()
    {
        game.Status = Game.GAME_STATUS.Ready;
        score.Init();
        UpdateUI();
    }

    public void GameOver()
    {
        game.Status = Game.GAME_STATUS.GameOver;
        UpdateUI();
    }
    

}
