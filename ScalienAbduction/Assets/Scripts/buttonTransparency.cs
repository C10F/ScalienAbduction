using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonTransparency : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Color col = GetComponent<Image>().color;
        col.a = 0;
        GetComponent<Image>().color = col;
    }
}
