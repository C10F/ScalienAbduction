using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiScalingMeter : MonoBehaviour
{
    // public nicolaisScript nicolaiScaleJuice;
    public Slider mainSlider;
    int scaleJuice = 75;

    public Color green = new Color(0, 1, 0);
    public Color yellow = new Color(1, 1, 0);
    public Color red = new Color(1, 0, 0);


    void scaleJuiceMeter()
    {
        // scaleJuice =  nicolaiScaleJuice.getScaleJuice
        mainSlider.value = scaleJuice;

        if (mainSlider.value < 50)
        {
            mainSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = green;
        }

        if (mainSlider.value >= 50 && mainSlider.value < 75)
        {
            mainSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = yellow;
        }

        if (mainSlider.value >= 75)
        {
            mainSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = red;
        }
    }

    void Update()
    {
        scaleJuiceMeter();
    }
}
