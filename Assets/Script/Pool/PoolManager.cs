using System.Runtime.CompilerServices;
using System.Security.Authentication.ExtendedProtection;
using System.Security.AccessControl;
using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>
[System.Serializable]
public class PoolManager : Singleton<PoolManager>
{
     [SerializeField] Pool[]  playerPools;
     [SerializeField] Pool[]  bulletPools;
     [SerializeField] Pool[]  enemyPools;
     [SerializeField] Pool[]  deliveryPools;
     static Dictionary<GameObject, Pool> dictionary;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        dictionary = new Dictionary<GameObject, Pool>();
        Initialize(playerPools);
        Initialize(enemyPools);
        Initialize(deliveryPools);
        Initialize(bulletPools);
    }

    void Initialize(Pool[] pools)
    {
        foreach(var pool in pools)
        {
            #if UNITY_EDITOR
            if(dictionary.ContainsKey(pool.prefab))
            {
                Debug.LogError("Same prefab"+ pool.prefab.name);
                continue;
            }
            #endif

            dictionary.Add(pool.prefab, pool);
            Transform poolParent = new GameObject("Pool:" + pool.prefab.name).transform;
            poolParent.parent = transform;

            pool.Initialize(poolParent);
        }
    }

    #if UNITY_EDITOR
    void OnDestroy()
    {
        CheckPoolSize(playerPools);    
    }
    #endif


    void CheckPoolSize(Pool[] pools)
    {
        foreach(var pool in pools)
        {
            if(pool.RuntimeSize > pool.Size)
            {
                Debug.LogWarning(
                    string.Format("Pool:{0} has a runtime size{1} is bigger than its initial size{2}",
                    pool.prefab.name,
                    pool.RuntimeSize,
                    pool.Size
                    ));
            }
        }
    }


    public static GameObject Release(GameObject prefab)
    {
        Debug.Log(prefab);
        #if UNITY_EDITOR
        if(!dictionary.ContainsKey(prefab))
        {
            Debug.LogError("Not have prefab");
            return null;
        }
        #endif
        return dictionary[prefab].preparedObject();
    }

    public static GameObject Release(GameObject prefab, Vector3 postion)
    {
        #if UNITY_EDITOR
        if(!dictionary.ContainsKey(prefab))
        {
            Debug.LogError("Not have prefab");
            return null;
        }
        #endif
        return dictionary[prefab].preparedObject(postion);
    }

    public static GameObject Release(GameObject prefab, Vector3 postion, Quaternion rotation)
    {
        #if UNITY_EDITOR
        if(!dictionary.ContainsKey(prefab))
        {
            Debug.LogError("Not have prefab");
            return null;
        }
        #endif
        return dictionary[prefab].preparedObject(postion, rotation);
    }
}
