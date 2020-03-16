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

        if (newScale == smallCube && !overColliding)
        {
            transform.localScale = mediumCube;
            this.tag = "Medium Cube";
        }

        if (newScale == mediumCube && !overColliding)
        {
            transform.localScale = largeCube;
            this.tag = "Large Cube";
        }

        if (newScale == largeCube && !overColliding)
        {
            Debug.Log("Cube is too large!");
        }
    }

    void downScale()
    {
        Vector3 newScale = transform.localScale; // What is the current size?

        if (newScale == smallCube && !overColliding)
        {
            Debug.Log("Cube is too small!");
        }

        if (newScale == mediumCube && !overColliding)
        {
            transform.localScale = smallCube;
            this.tag = "Small Cube";
        }

        if (newScale == largeCube && !overColliding)
        {
            transform.localScale = mediumCube;
            this.tag = "Medium Cube";
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Player")
            overColliding = true;
        Debug.Log("Colliding");
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
            overColliding = false;
        Debug.Log("Colliding");
    }
}