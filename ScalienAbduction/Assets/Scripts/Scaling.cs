using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour
{

    Vector3 scaleChange;

    bool overColliding = false;

    Vector3 smallCube = new Vector3(200f, 200f, 200f);
    Vector3 mediumCube = new Vector3(500f, 500f, 500f);
    Vector3 largeCube = new Vector3(1000f, 1000f, 1000f);



    // Start is called before the first frame update
    void Start()
    {
    }

    void upScale()
    {
        Vector3 newScale = transform.localScale; // What is the current size?

        if (scaleManager.currentScaleWeight < scaleManager._scaleUpperThreshold && newScale == smallCube && !overColliding)
        {
            transform.localScale = mediumCube;
            this.tag = "Medium Cube";
            scaleManager.currentScaleWeight += 1;
            Debug.Log("Current scale weight is: " + scaleManager.currentScaleWeight);
        }

        if (scaleManager.currentScaleWeight < scaleManager._scaleUpperThreshold && newScale == mediumCube && !overColliding)
        {
            transform.localScale = largeCube;
            this.tag = "Large Cube";
            scaleManager.currentScaleWeight += 1;
            Debug.Log("Current scale weight is: " + scaleManager.currentScaleWeight);
        }

        if (scaleManager.currentScaleWeight < scaleManager._scaleUpperThreshold && newScale == largeCube && !overColliding)
        {
            Debug.Log("Cube is too large!");
        }

        else if (scaleManager.currentScaleWeight == scaleManager._scaleUpperThreshold && (newScale == smallCube || newScale == mediumCube || newScale == largeCube) && !overColliding)
        {
            Debug.Log("You've exeeded the scaling threshold aka you got no juice left!");
        }
        
    }

    void downScale()
    {
        Vector3 newScale = transform.localScale; // What is the current size?

        if (scaleManager.currentScaleWeight > scaleManager._scaleLowerThreshold && newScale == smallCube && !overColliding)
        {
            Debug.Log("Cube is too small!");
        }

        if (scaleManager.currentScaleWeight > scaleManager._scaleLowerThreshold && newScale == mediumCube && !overColliding)
        {
            transform.localScale = smallCube;
            this.tag = "Small Cube";
            scaleManager.currentScaleWeight -= 1;
            Debug.Log("Current scale weight is: " + scaleManager.currentScaleWeight);
        }

        if (scaleManager.currentScaleWeight > scaleManager._scaleLowerThreshold && newScale == largeCube && !overColliding)
        {
            transform.localScale = mediumCube;
            this.tag = "Medium Cube";
            scaleManager.currentScaleWeight -= 1;
            Debug.Log("Current scale weight is: " + scaleManager.currentScaleWeight);
        }

        else if (scaleManager.currentScaleWeight == scaleManager._scaleLowerThreshold && (newScale == smallCube || newScale == mediumCube || newScale == largeCube) && !overColliding)
        {
            Debug.Log("You've reached the lower threshold aka you got no juice left!");
        }
    }

    //void OnCollisionStay(Collision collision)
    //{
    //    if (collision.collider.tag == "Player")
    //        overColliding = true;
    //    Debug.Log("Colliding");
    //}
    //void OnCollisionExit(Collision collision)
    //{
    //    if (collision.collider.tag == "Player")
    //        overColliding = false;
    //    Debug.Log("Colliding");
    //}
}