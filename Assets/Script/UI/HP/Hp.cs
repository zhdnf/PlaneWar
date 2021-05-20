using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
*/

/// <summary>
///
/// </summary>

public class Hp : MonoBehaviour
{
    public GameObject panelHP;
    public Slider hpSlider;
    private float hp;

    public float HP
    {
        get { return this.hp; }
        set { this.hp = value;
              HPUpdate(this.hp);
            }
    }

    void Start()
    {
       
    }

    public void Init(float hp)
    {
        if(hp > 100)
        {
            hpSlider.maxValue = hp;
        }

        this.HP = hp;
        this.SetActive(true);
    }

    public void SetActive(bool active)
    {
        if(active == true)
        {
            panelHP.SetActive(true);
        }
        else
        {
            panelHP.SetActive(false);
        }
    }

    public void HPUpdate(float newHp)
    {
        hpSlider.value = newHp; 
    }

}
