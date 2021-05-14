using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
*/

/// <summary>
///
/// </summary>

public class UIScore : MonoBehaviour
{
    public Game game;
    public Player player;

    public MyUI ui;

    public int score;

    public int Score
    {
        get { return score; }
        set
        {
            this.score = value;
        }
    }

    public void Init()
    {
        if(game.Status == Game.GAME_STATUS.Ready)
        {
            this.Score = 0;
        }
    }



}
