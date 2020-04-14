using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleManager : MonoBehaviour
{
    public bool onPlate = false;
    public int scaleUpperThreshold;
    public int scaleLowerThreshold;
    public static int _scaleUpperThreshold;
    public static int _scaleLowerThreshold;

    public static int currentScaleWeight;
    public GameObject[] cubes;
    
    // Start is called before the first frame update
    void Awake()
    {
        _scaleLowerThreshold = scaleLowerThreshold;
        Debug.Log("Lower scale threshold is set to: " + _scaleLowerThreshold);

        _scaleUpperThreshold = scaleUpperThreshold;
        Debug.Log("Upper scale threshold is set to: " + _scaleUpperThreshold);

        currentScaleWeight = ScaleWeight._scaleWeight;
    }

    void FixedUpdate() 
    {
        if (currentScaleWeight != GetWeight()) currentScaleWeight = GetWeight();
    }

    int GetWeight() 
    {
        int temp = 0;
        for (int i = 0; i < cubes.Length; i++) 
        {
            temp += cubes[i].GetComponent<ScaleWeight>().scaleWeight;
        }
        return temp;
    }
}
