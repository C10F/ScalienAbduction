using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public RaycastHit hit; // To get information back from Raycast
    public int reach = 10;
    // Update is called once per frame
    void Update()
    {
        HitByRay(); // Run HitByRay
    }

    void HitByRay()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance: reach)) // If the raycast strikes a collider within 15 distance
        {
            if (hit.transform.tag == "Small Cube" || hit.transform.tag == "Medium Cube") // If object has suitable tag
            {
                if (Input.GetKeyDown("e")) // If 'e' is pressed
                {
                        if(hit.transform.tag == "Small Cube") { hit.transform.SendMessage("pickUp"); } // If small cube, send pickup message
                        if (hit.transform.tag == "Medium Cube") { hit.transform.SendMessage("push"); } // If medium cube, send push message
                }
            }

                if (Input.GetKeyDown("r") && (hit.transform.tag == "Small Cube" || hit.transform.tag == "Medium Cube" || hit.transform.tag == "Large Cube")) // If suitable tag and 'r' is pressed
                {
                    hit.transform.SendMessage("downScale"); // send message downScale
                }
                if (Input.GetKeyDown("t") && (hit.transform.tag == "Small Cube" || hit.transform.tag == "Medium Cube" || hit.transform.tag == "Large Cube")) // If suitable tag and 't' is pressed
                {
                    hit.transform.SendMessage("upScale"); // send message upScale
                }
        }
    }
}
