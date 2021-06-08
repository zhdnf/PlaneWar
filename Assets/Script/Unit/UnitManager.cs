using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///  EnemyManager 生成一个敌人
/// </summary>

public class UnitManager : Singleton<UnitManager>
{

    public Player player;
    Transform enemyTarget;
    Transform bossTarget;
    Transform deliveryTarget;
    
    public List<Enemy> enemiesList = new List<Enemy>();



    public void Clear()
    {
        //删除当前屏幕中的对象
        for(int i=0; i<enemiesList.Count; i++)
        {
            // 有可能有已删除的对象为null
            if(this.enemiesList[i] == null)
            {

            }
            else
            {
                Destroy(enemiesList[i].gameObject);
            }
        }
        //this.enemiesList.Clear();
    }

    public Enemy GenerateEnemy(GameObject templates)
    {
        if (templates == null)
        {
            return null;
        }
        //实例化对象
        GameObject enemiesObject = PoolManager.Release(templates);
        Enemy p = enemiesObject.GetComponent<Enemy>();
        this.enemiesList.Add(p);
        return p;
    }




} 