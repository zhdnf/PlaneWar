using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///  EnemyManager 生成一个敌人
/// </summary>

public class UnitManager : MonoBehaviour
{
    public GameObject enemyTemplate;
    public List<Enemy> enemiesList = new List<Enemy>();

    public Enemy enemy;

    Coroutine coroutine = null;

    // 产生敌人的速度
    public float speed=2;

    public float minRange = -3;
    public float maxRange = 3;

    void Start()
    {

    }
    public void EnemyManagerStart()
    {
        coroutine = StartCoroutine(GeneratorsEnemy());

    }

    public void EnemyManagerStop()
    {
        StopCoroutine(coroutine);
        //有时间差
        //for (int i = 0; i < enemieslist.count; i++)
        //{
        //    if (enemieslist[i].gameobject == null)
        //    {

        //    }
        //    else
        //    {
        //        destroy(enemieslist[i].gameobject);
        //    }
        //}
        this.enemiesList.Clear();
    }
    IEnumerator GeneratorsEnemy()
    {
        while (true)
        {
            GenerateEnemy();
            yield return new WaitForSeconds(this.speed);
        }
    }

    public void GenerateEnemy()
    {

         //实例化对象
        GameObject enemiesObject = Instantiate(enemyTemplate, this.transform) as GameObject;
        Enemy p = enemiesObject.GetComponent<Enemy>();
        this.enemiesList.Add(p);

  
        this.transform.position = new Vector3(12, Random.Range(minRange, maxRange), 0);

    }



} 