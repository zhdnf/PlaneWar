using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*/

/// <summary>
///
/// </summary>

// 单例模式
public class Singleton<T> : MonoBehaviour where T: MonoBehaviour
{
    static T instance;

    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                //找绑定的对象
                //new 创建对象与绑定对象不一样
                instance = (T)FindObjectOfType<T>();
            }
            return instance;
        }
    }
}
