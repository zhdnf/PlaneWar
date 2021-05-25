using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
*/

/// <summary>
///
/// </summary>

public class AtomicUI : MonoBehaviour
{
    //检查是否使用
    bool[] isUse;
    //放置照片
    Image[] images;
        
    private void Start()
    {
        images = this.GetComponentsInChildren<Image>();
        isUse = new bool[images.Length];
        for (int i = 0; i < isUse.Length; i++)
        {
            isUse[i] = false;
        }
    }

    public void OnAtomicUse()
    {
        for (int i = isUse.Length - 1; i >= 0; i--)
        {
            if (isUse[i] == false)
            {
                images[i].enabled = false;
                isUse[i] = true;
                break;
            }
        }
    }

    // 吃道具补充
    public void OnAtomicSupplement()
    {

    }
}
