using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleManager : MonoBehaviour
{
    public int scaleUpperThreshold;
    public int scaleLowerThreshold;
    public static int _scaleUpperThreshold;
    public static int _scaleLowerThreshold;

    public static int currentScaleWeight;

    // Start is called before the first frame update
    void Awake()
    {
        _scaleLowerThreshold = scaleLowerThreshold;
        Debug.Log("Lower scale threshold is set to: " + _scaleLowerThreshold);

        _scaleUpperThreshold = scaleUpperThreshold;
        Debug.Log("Upper scale threshold is set to: " + _scaleUpperThreshold);

        currentScaleWeight = ScaleWeight._scaleWeight;
        Debug.Log("Current scale weight is: " + currentScaleWeight);
    }
}
