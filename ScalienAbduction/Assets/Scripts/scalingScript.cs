using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scalingScript : MonoBehaviour
{
  
    Vector3 scaleChange;

    Vector3 smallCube = new Vector3(2.0f, 2.0f, 2.0f);
    Vector3 mediumCube = new Vector3(5.0f, 5.0f, 5.0f);
    Vector3 largeCube = new Vector3(10.0f, 10.0f, 10.0f);



    // Start is called before the first frame update
    void Start()
    {
    }

    void upScale()
    {
        Vector3 newScale = transform.localScale; // What is the current size?

        if (newScale == smallCube)
        {
            transform.localScale = mediumCube;
        }

        if (newScale == mediumCube)
        {
            transform.localScale = largeCube;
        }

        if (newScale == largeCube)
        {
            Debug.Log("Cube is too large!");
        }
    }

    void downScale()
    {
        Vector3 newScale = transform.localScale; // What is the current size?

        if (newScale == smallCube)
        {
            Debug.Log("Cube is too small!");
        }

        if (newScale == mediumCube)
        {
            transform.localScale = smallCube;
        }

        if (newScale == largeCube)
        {
            transform.localScale = mediumCube;
        }
    }
}
