using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
*/

/// <summary>
///
/// </summary>

public class Level : MonoBehaviour
{
    public int LevelID;
    public string LevelName;

    public Boss Boss;

    public List<SpawnRule> Rules = new List<SpawnRule>();

    public enum LEVEL_RESULT
    {
        NONE,
        SUCCESS,
        FAILED
    }
    public UnityAction<LEVEL_RESULT> OnLevelEnd;
    public LEVEL_RESULT result = LEVEL_RESULT.NONE;

    // 开始时间
    public float timeSinceLevelStart = 0;
    // 当前时间
    public float levelStartTime = 0;
    // Boss出场时间
    public float bossTimer = 50;
    
    public float timer;

    Boss boss = null;
    bool bossIsDead = false;

    void Start()
    {
        StartCoroutine(RunLevel());
    }

    IEnumerator RunLevel()
    {
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < Rules.Count; i++)
        {
            SpawnRule rule = Instantiate<SpawnRule>(Rules[i]);
        }

    }

    private void Update()
    {
        if(Game.Instance.player.HP <= 0)
        {
            return;
        }

        this.timeSinceLevelStart = Time.realtimeSinceStartup - levelStartTime;
        if(this.result != LEVEL_RESULT.NONE)
        {
            return;
        }
        if (this.timeSinceLevelStart > bossTimer)
        {
            if (boss == null && bossIsDead == false)
            {
                timer = 0;
                boss = (Boss)UnitManager.Instance.GenerateEnemy(this.Boss.gameObject);
                boss.Fly();
                boss.target = UnitManager.Instance.player;
                boss.OnDeath += Boss_OnDeath;
            }
        }
    }

    public void Boss_OnDeath(Unit sender)
    {
        this.bossIsDead = true;
        this.result = LEVEL_RESULT.SUCCESS;

        if (this.OnLevelEnd != null)
        {
            this.OnLevelEnd(this.result);
        }
    }
}
