using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public RaycastHit hit; // To get information back from Raycast
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HitByRay();
    }
    void HitByRay()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit)) // If object is hit by raycast
        {
            if (hit.distance > 3 && hit.transform.tag == "SuitableTagName")
            {
                // Do something, enable to pick-up etc.
            }
        }
    }
}
