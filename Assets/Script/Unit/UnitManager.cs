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
    public Transform enemyTarget;
    public Transform bossTarget;
    public Transform deliveryTarget;


    public Unit Generate(GameObject templates, string name)
    {
        Unit obj;
        Vector3 pos;
    

        if (templates == null)
        {
            return null;
        }

        GameObject unitObject = PoolManager.Release(templates);

        switch(name)
        {
            case "Enemy":
                obj = unitObject.GetComponent<Enemy>();
                pos = enemyTarget.position;
                break;
            case "Boss":
                obj = unitObject.GetComponent<Boss>();
                pos = bossTarget.position;
                break;
            case "Delivery":
                obj = unitObject.GetComponent<Delivery>();
                pos = deliveryTarget.position;
                break;
            default:
                Debug.LogError("name is error");
                return null;
        }
        
        obj.transform.position = pos;

        return obj;
    }




} 