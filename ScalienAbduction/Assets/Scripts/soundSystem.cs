﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundSystem : MonoBehaviour
{

    public AudioSource aData;

    // Start is called before the first frame update
    void Start()
    {
        aData.PlayDelayed(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}