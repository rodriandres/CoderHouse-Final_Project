using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image imgHealthBar;

    public Text txtHealth;

    public int Min;

    public int Max;

    private int mCurrentValue;

    private float mCurrentPercent;

    public void SetHealth(int health)
    {
        if (health != mCurrentValue)
        {
            if (Min - Max == 0)
            {
                mCurrentValue = 0;
                mCurrentPercent = 0;
            }
            else
            {
                mCurrentValue = health;

                mCurrentPercent = (float)mCurrentValue / (float)(Max - Min);
            } 
        }

        txtHealth.text = string.Format("{0} %", Mathf.RoundToInt(mCurrentPercent * 100));

        imgHealthBar.fillAmount = mCurrentPercent;
    }

    public float CurrentPercent
    {
        get { return mCurrentPercent; }
    }

    public float CurrentValue
    {
        get { return mCurrentValue; }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetHealth(41);
        
    }
}
