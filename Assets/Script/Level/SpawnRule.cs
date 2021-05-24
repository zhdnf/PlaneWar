using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

public class SpawnRule : MonoBehaviour
{
    public Unit Monster;
    public float InitTime;
    public float timeCycle;
    public int MaxNum;

    public float HP;
    public float Attack;
    public int Score;

    // 游戏当前时间
    public float timeSinceLevelStart = 0;
    float levelStartTime = 0;

    int currentNum = 0;

    public bool isGame = false;

    float timer = 0;

    public ItemDropRule ItemDropRule;
    ItemDropRule rule;

    private void Start()
    {
        if(ItemDropRule != null)
        {
            rule = Instantiate<ItemDropRule>(ItemDropRule);
        }
    }

    // 规则逻辑
    private void Update()
    {
        // 主角死亡什么也不干
        if (Game.Instance.player.death == true)
        {
            return;
        }

        this.timeSinceLevelStart = Global.levelRunTime - levelStartTime;
        if(this.currentNum > this.MaxNum)
        {
            return;
        }
        if(timeSinceLevelStart > InitTime)
        {
            timer += Time.deltaTime;
            if(timer > timeCycle)
            {
                timer = 0;
                Enemy enemy = UnitManager.Instance.GenerateEnemy(this.Monster.gameObject);
                enemy.HP = this.HP;
                enemy.power = this.Attack;
                enemy.score = this.Score;
                enemy.OnDeath += Enemy_OnDeath;
                enemy.onScore += MyUI.Instance.OnScore;

                currentNum++;
                
            }
        }
        
    }

    public void Enemy_OnDeath(Unit sender)
    {
        if(ItemDropRule != null)
        {
            rule.Execute(sender.transform);
        }

    }

    public void Init()
    {
        timer = 0;
        currentNum = 0;
        levelStartTime = 0;
        timeSinceLevelStart = 0;
    }
}
