using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image imgHealthBar;
    public Text txtHealth;
    int max;
    int min;

    private int myCurrentScaleValue;
    private float myCurrentScalePercent;

    // Start is called before the first frame update
    void Start()
    {
        max = scaleManager._scaleUpperThreshold;
        min = scaleManager._scaleLowerThreshold;

        //*100 / scaleManager.currentScaleWeight
    }

    // Update is called once per frame
    void Update()
    {
        setScaleValue(scaleManager.currentScaleWeight);
    }

    public void setScaleValue(int tempScaleValue)
    {
        if (tempScaleValue != myCurrentScaleValue)
        {
            if (max - min == 0)
            {
                myCurrentScaleValue = 0;
                myCurrentScalePercent = 0;
            }
            else
            {
                myCurrentScaleValue = tempScaleValue;

                myCurrentScalePercent = map(myCurrentScaleValue, min, max, 0, 100);
            }

            txtHealth.text = string.Format("{0} %", Mathf.RoundToInt(myCurrentScalePercent));

            imgHealthBar.fillAmount = myCurrentScalePercent / 100;
        }
    }

    public float CurrentScalePercent
    {
        get { return myCurrentScalePercent; }
    }

    public int CurrentScaleValue
    {
        get { return myCurrentScaleValue; }
    }

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
}
