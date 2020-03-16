using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public RaycastHit hit; // To get information back from Raycast
    public GameObject TheHitBox;
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
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance: 10))
        {
            Debug.Log("Looking at: " + hit.transform);
            if (hit.transform.tag == "Small Cube" || hit.transform.tag == "Medium Cube")
            {
                if (Input.GetKeyDown("e"))
                {
                    if (TheHitBox == null)
                    {
                        if(hit.transform.tag == "Small Cube") { hit.transform.SendMessage("pickUp"); }
                        if (hit.transform.tag == "Medium Cube") { hit.transform.SendMessage("push"); }
                        TheHitBox = hit.collider.gameObject;
                    }
                    else { TheHitBox = null; }
                }
            }
            if (hit.transform.tag == "Medium Cube")
            {
                //Run code when looking at cube, indicator code?

                if (Input.GetKeyDown("e"))
                {
                    //Run code when pressing 'e' on cube, pickup or shove?
                    Debug.Log("Pressed to pickup medium cube");
                }
                if (Input.GetKeyDown("r"))
                {
                    //Run code when pressing 'r' on cube, scale up.
                    hit.transform.SendMessage("InsertUpScalingMethodName");
                }
                if (Input.GetKeyDown("t"))
                {
                    //Run code when pressing 't' on cube, scale up.
                    hit.transform.SendMessage("InsertDownScalingMethodName");
                }
            }
        }
    }
}
