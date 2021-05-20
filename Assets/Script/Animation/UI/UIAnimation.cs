using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
*/

/// <summary>
///
/// </summary>

public class UIAnimation : MonoBehaviour, AnimationInterface
{
    public Text Container;
    public Animator UIAnimator;

    public void Action(string action)
    {
        switch (action)
        {
            case "start":
                this.GameStart();
                break;
            case "end":
                this.GameEnd();
                break;
            default:
                Debug.LogError("action is error");
                return;
        }
    }

    public void GameStart()
    {
        int currentId = LevelManager.Instance.currentLevelID;
        this.Container.text = string.Format("LEVEL{0}: {1}", currentId.ToString(),
                                LevelManager.Instance.Levels[currentId - 1].LevelName);
        this.UIAnimator.SetTrigger("start");
    }

    public void GameEnd()
    {
        this.Container.text = "GAME OVER";
        this.UIAnimator.SetTrigger("end");
    }
}