using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private Heart[] hearts;
    [SerializeField] private Bar bar;
    [SerializeField] private CanvasGroup shieldGroup;
    private int index = -1;
    
    public static HUD instance;

    private void Awake()
    {
        instance = this;
    }


    public void HeartDmg()
    {   
        if (index < 3)
        {

            index++;

            hearts[index].SwapHeart(1);
        }
    }

    public void HeartHeal()
    {
        index = -1;

        hearts[0].SwapHeart(0);

        hearts[1].SwapHeart(0);

        hearts[2].SwapHeart(0);

        hearts[3].SwapHeart(0);
    }

    public void EvoUp()
    {
        bar.SwapBar();
    }

    public void EvoReset()
    {
        bar.ResetBar();
    }

    public void EnableShield()
    {
        shieldGroup.alpha = 1;
    }
}
