using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour
{

    Vector3 smallCube = new Vector3(200.0f, 200.0f, 200.0f);
    Vector3 mediumCube = new Vector3(500f, 500f, 500f);
    Vector3 largeCube = new Vector3(1000f, 1000f, 1000f);

    public Vector3 velocity = Vector3.zero;

    float delta = 2f;

    int s = 1;
    int m = 2;
    int l = 3;

    IEnumerator smoothUpscale(Vector3 targetCube, float tempSmoothSpeed)
    {
        while (Mathf.Abs(transform.localScale.magnitude - targetCube.magnitude) > delta)
            {
            yield return new WaitForEndOfFrame();
            transform.localScale = Vector3.SmoothDamp(transform.localScale, targetCube, ref velocity, tempSmoothSpeed);
            }
        gameObject.GetComponent<PickUp>().ready = true;
        yield return null;
    }

    IEnumerator smoothDownscale(Vector3 targetCube, float tempSmoothSpeed)
    {
        while (Mathf.Abs(transform.localScale.magnitude - targetCube.magnitude) > delta)
        {
            yield return new WaitForEndOfFrame();
            transform.localScale = Vector3.SmoothDamp(transform.localScale, targetCube, ref velocity, tempSmoothSpeed);
        }
        gameObject.GetComponent<PickUp>().ready = true;
        yield return null;
    }

    void upScale()
    {
        float smoothSpeed = 0.2f;

        if (this.transform.tag == "Large Cube")
        {
            Debug.Log("Cube is too large!");
        }

        if (this.transform.tag == "Medium Cube")
        {
            if (scaleManager.currentScaleWeight < scaleManager._scaleUpperThreshold) 
            {
                if (Mathf.Abs(transform.localScale.magnitude - mediumCube.magnitude) < delta)
                {
                    this.tag = "Large Cube";
                    gameObject.GetComponent<PickUp>().ready = false;
                    StartCoroutine(smoothUpscale(largeCube, smoothSpeed));
                    this.GetComponent<ScaleWeight>().scaleWeight = l;
                }
                
                //scaleManager.currentScaleWeight += 1;

                //Debug.Log("Current scale weight is: " + scaleManager.currentScaleWeight);
            }

        }

        if (this.transform.tag == "Small Cube")
        {
            if (scaleManager.currentScaleWeight < scaleManager._scaleUpperThreshold)
            {
                if (Mathf.Abs(transform.localScale.magnitude - smallCube.magnitude) < delta)
                {
                    this.tag = "Medium Cube";
                    gameObject.GetComponent<PickUp>().ready = false;
                    StartCoroutine(smoothUpscale(mediumCube, smoothSpeed));
                    this.GetComponent<ScaleWeight>().scaleWeight = m;
                }
            }

        }
    }

    void downScale()
    {
        float smoothSpeed = 0.2f;

        if (this.transform.tag == "Small Cube")
        {
            Debug.Log("Cube is too small!");
        }

        if (this.transform.tag == "Medium Cube")
        {
            if (scaleManager.currentScaleWeight > scaleManager._scaleLowerThreshold)
            {
                //scaleManager.currentScaleWeight -= 1;

                if (Mathf.Abs(transform.localScale.magnitude - mediumCube.magnitude) < delta)
                {
                    this.tag = "Small Cube";
                    gameObject.GetComponent<PickUp>().ready = false;
                    StartCoroutine(smoothDownscale(smallCube, smoothSpeed));
                    this.GetComponent<ScaleWeight>().scaleWeight = s;
                }
                //Debug.Log("Current scale weight is: " + scaleManager.currentScaleWeight);
            }

        }

        if (this.transform.tag == "Large Cube")
        {
            if (scaleManager.currentScaleWeight > scaleManager._scaleLowerThreshold)
            { 

                //scaleManager.currentScaleWeight -= 1;
                if (Mathf.Abs(transform.localScale.magnitude - largeCube.magnitude) < delta)
                {
                    this.tag = "Medium Cube";
                    gameObject.GetComponent<PickUp>().ready = false;
                    StartCoroutine(smoothDownscale(mediumCube, smoothSpeed));
                    this.GetComponent<ScaleWeight>().scaleWeight = m;
                }
                //Debug.Log("Current scale weight is: " + scaleManager.currentScaleWeight);
            }
          
        }
    }
}