using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleWeight : MonoBehaviour
{
    public int scaleWeight;
    public static int _scaleWeight;

    // Start is called before the first frame update
    void Awake()
    {
       _scaleWeight += scaleWeight;
    }

    // Update is called once per frame

}
