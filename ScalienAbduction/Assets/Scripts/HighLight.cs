using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLight : MonoBehaviour
{
    bool highlight;
    float timer;
    public Material thisMat;
    private void Awake()
    {
        thisMat = gameObject.GetComponent<Renderer>().material;
    }

        // Update is called once per frame
        void Update()
    {
        if(highlight)
        {
            timer += Time.deltaTime;

            if (timer > 0.2)
            {
                highlight = false;
                thisMat.SetColor("_ColorTint", Color.white);
            }
        }
    }

    void Highlight() // When highlight message recieved from RayCast.cs
    {
        timer = 0;
        if (!highlight) // If highlight is false
        {
            highlight = true;
            thisMat.SetColor("_ColorTint", Color.green);
        }
    }


}
