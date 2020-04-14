using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLight : MonoBehaviour
{
    Color enable = new Color(0, 1, 0, 0.4f);
    Color disable = new Color(1, 1, 1, 0.1f);
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
                thisMat.SetColor("_BaseColor", disable);
            }
        }
    }

    void Highlight() // When highlight message recieved from RayCast.cs
    {
        timer = 0;
        if (!highlight) // If highlight is false
        {
            highlight = true;
            thisMat.SetColor("_BaseColor", enable);
        }
    }


}
