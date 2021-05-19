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

    float timeSinceLevelStart = 0;
    float levelStartTime = 0;

    int currentNum = 0;

    float timer = 0;

    private void Start()
    {
        this.levelStartTime = Time.realtimeSinceStartup;
    }

    // 规则逻辑
    private void Update()
    {
        this.timeSinceLevelStart = Time.realtimeSinceStartup - levelStartTime;
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
                currentNum++;

            }
        }
        
    }


}
