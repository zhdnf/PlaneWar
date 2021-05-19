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
    public List<Enemy> enemiesList = new List<Enemy>();

    public void Clear()
    {
        this.enemiesList.Clear();
    }

    public Enemy GenerateEnemy(GameObject template)
    {
        if (template == null)
        {
            return null;
        }
        //实例化对象
        GameObject enemiesObject = Instantiate(template, this.transform) as GameObject;
        Enemy p = enemiesObject.GetComponent<Enemy>();
        this.enemiesList.Add(p);
        return p;

    }




} 