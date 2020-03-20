using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour
{

    Vector3 smallCube = new Vector3(200.0f, 200.0f, 200.0f);
    Vector3 mediumCube = new Vector3(500f, 500f, 500f);
    Vector3 largeCube = new Vector3(1000f, 1000f, 1000f);

    void upScale()
    {

        Vector3 newScale = transform.localScale; // What is the current size?

        if (this.transform.tag == "Large Cube")
        {
            //Insert something?
        }

        if (this.transform.tag == "Medium Cube")
        {
            transform.position = transform.position + new Vector3(0, 3, 0);
            transform.localScale = largeCube;
            this.tag = "Large Cube";
        }

        if (this.transform.tag == "Small Cube")
        {
            transform.position = transform.position + new Vector3(0,1.5f,0);
            transform.localScale = mediumCube;
            this.tag = "Medium Cube";
        }
    }

    void downScale()
    {
        Vector3 newScale = transform.localScale; // What is the current size?

        if (this.transform.tag == "Small Cube")
        {
            // Insert something?
        }

        if (this.transform.tag == "Medium Cube")
        {
            transform.localScale = smallCube;
            this.tag = "Small Cube";
        }

        if (this.transform.tag == "Large Cube")
        {
            transform.localScale = mediumCube;
            this.tag = "Medium Cube";
        }
    }
}