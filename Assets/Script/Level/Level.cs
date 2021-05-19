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

    public List<SpawnRule> Rules = new List<SpawnRule>();

    public enum LEVEL_RESULT
    {
        NONE,
        SUCCESS,
        FAILED
    }
    public UnityAction<LEVEL_RESULT> OnLevelEnd;
    public LEVEL_RESULT result = LEVEL_RESULT.NONE;
    //public float timeSinceLevelStart=0;
    //public float levelStartTime=0;
    //public float bossTimer;
    //public float timer;
    //Boss boss = null;

    private void Start()
    {
        for (int i = 0; i < Rules.Count; i++)
        {
            SpawnRule rule = Instantiate<SpawnRule>(Rules[i]);
        }
    }

    private void Update()
    {
        //this.timeSinceLevelStart = Time.realtimeSinceStartup - levelStartTime;
        if(this.result != LEVEL_RESULT.NONE)
        {
            return;
        }
        //if (timeSinceLevelStart > bossTimer)
        //{
        //    if (boss == null)
        //    {
        //        timer = 0;
        //        boss = (Boss)UnitManager.Instance.GenerateEnemy(this.boss.gameObject);
        //        boss.fly();
        //        boss.target = UnitManager.Instance.player;
        //        boss.onDeath += Boss_OnDeath;
        //
        //
        //}
        //}
    }

    public void Boss_OnDeath()
    {
        this.result = LEVEL_RESULT.SUCCESS;
        if (this.OnLevelEnd != null)
        {
            this.OnLevelEnd(this.result);
        }
    }
}
