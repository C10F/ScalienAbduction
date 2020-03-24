using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour
{

    Vector3 smallCube = new Vector3(200.0f, 200.0f, 200.0f);
    Vector3 mediumCube = new Vector3(500f, 500f, 500f);
    Vector3 largeCube = new Vector3(1000f, 1000f, 1000f);

    int s = 1;
    int m = 2;
    int l = 3;

    void upScale()
    {

        Vector3 newScale = transform.localScale; // What is the current size?

        if (this.transform.tag == "Large Cube")
        {
            //Insert something?
            Debug.Log("Cube is too large!");
        }

        if (this.transform.tag == "Medium Cube")
        {
            if (scaleManager.currentScaleWeight < scaleManager._scaleUpperThreshold) 
            {
                transform.position = transform.position + new Vector3(0, 3, 0);
                transform.localScale = largeCube;
                //scaleManager.currentScaleWeight += 1;
                this.GetComponent<ScaleWeight>().scaleWeight = l;
                this.tag = "Large Cube";
                //Debug.Log("Current scale weight is: " + scaleManager.currentScaleWeight);
            }

        }

        if (this.transform.tag == "Small Cube")
        {
            if (scaleManager.currentScaleWeight < scaleManager._scaleUpperThreshold)
            {
                transform.position = transform.position + new Vector3(0, 1.5f, 0);
                transform.localScale = mediumCube;
                //scaleManager.currentScaleWeight += 1;
                this.GetComponent<ScaleWeight>().scaleWeight = m;
                this.tag = "Medium Cube";
                //Debug.Log("Current scale weight is: " + scaleManager.currentScaleWeight);
            }

        }
    }

    void downScale()
    {
        Vector3 newScale = transform.localScale; // What is the current size?

        if (this.transform.tag == "Small Cube")
        {
            // Insert something?
            Debug.Log("Cube is too small!");
        }

        if (this.transform.tag == "Medium Cube")
        {
            if (scaleManager.currentScaleWeight > scaleManager._scaleLowerThreshold)
            {
                transform.localScale = smallCube;
                //scaleManager.currentScaleWeight -= 1;
                this.GetComponent<ScaleWeight>().scaleWeight = s;
                this.tag = "Small Cube";
                //Debug.Log("Current scale weight is: " + scaleManager.currentScaleWeight);
            }

        }

        if (this.transform.tag == "Large Cube")
        {
            if (scaleManager.currentScaleWeight > scaleManager._scaleLowerThreshold) 
            {
                transform.localScale = mediumCube;
                //scaleManager.currentScaleWeight -= 1;
                this.GetComponent<ScaleWeight>().scaleWeight = m;
                this.tag = "Medium Cube";
                //Debug.Log("Current scale weight is: " + scaleManager.currentScaleWeight);
            }
          
        }
    }
}