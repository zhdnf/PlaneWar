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
    public Player player;

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

        this.EnemyInit();

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
    public void EnemyInit()
    {
        for (int i = 0; i < enemiesList.Count; i++)
        {
            // enemy死亡时已经销毁了对象
            if (enemiesList[i] == null)
            {
                
            }
            else {
                Destroy(enemiesList[i].gameObject);
            }
            

        }
        enemiesList.Clear();
    }




} 