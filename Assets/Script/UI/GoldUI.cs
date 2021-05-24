using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
*/

/// <summary>
///
/// </summary>

public class GoldUI : MonoBehaviour
{

    private int nums;
    Text numsValue;
    public int Nums
    {
        get { return nums; }
        set
        {
            this.nums = value;
            this.UpdateGoldUI();
        }
    }

    public void Start()
    {
        numsValue = this.GetComponentInChildren<Text>();
    }

    public void UpdateGoldUI()
    {
        numsValue.text = string.Format("{0:D4}", this.nums);
    }
}
