using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/*
*/

/// <summary>
///
/// </summary>

public class UIScore : MonoBehaviour
{
    public int score;

    public Text gameScore;
    public Text endScore;

    public int Score
    {
        get { return score; }
        set
        {
            this.score = value;
            this.UpdateScore();
        }
    }

    public void Init()
    {
        this.Score = 0;
        this.UpdateScore();
    }

    public void UpdateScore()
    {
       
        gameScore.text = String.Format("{0:D10}", this.Score);
        endScore.text = this.Score.ToString();
    }

}
