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
    public GameObject enemy1Template;
    public GameObject enemy2Template;


    public List<Enemy> enemiesList = new List<Enemy>();

    public Enemy enemy;
    public Player player;
    public Boss boss;

    Coroutine coroutine = null;

    // 产生敌人的速度
    public float speed = 0;
    public float speed1= 1;
    public float speed2 = 2;
    public float speed3 = 3;

    public float minRange = -3;
    public float maxRange = 3;

    public void Start()
    {
    
    }

    public void Update()
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

    int timer1 = 0;
    int timer2 = 0;
    int timer3 = 0;

    IEnumerator GeneratorsEnemy()
    {
        while (true)
        {
            if(timer1 > 1)
            {
                speed = speed1;
                GenerateEnemy(enemyTemplate);
                timer1 = 0;
            }
            if(timer2 > 2)
            {
                speed = speed2;
                GenerateEnemy(enemy1Template);
                timer2 = 0;
            }

            if (timer3 > 3)
            {
                speed = speed3;
                GenerateEnemy(enemy2Template);
                timer3 = 0;
            }

            timer1++;
            timer2++;
            timer3++;
            yield return new WaitForSeconds(this.speed);
        }
    }

    public void GenerateEnemy(GameObject template)
    {
        if(template == null)
        {
            return;
        }
         //实例化对象
        GameObject enemiesObject = Instantiate(template, this.transform) as GameObject;
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