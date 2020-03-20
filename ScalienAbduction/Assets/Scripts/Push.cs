using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    public GameObject playerPosition; // Position of The Player Object
    public GameObject pushSpot; // Spot where the pushed object should be

    private bool pushed = false; // Boolean to keep track if an object is being pushed or not
    public bool Collision = false; //  Keep track if object is colliding

    public float pCorrectionForce = 5.0f; // Force used to correct path of object back to target position

    private float time; // Float used to set a timer between being able to pick-up and put down items.

    private void Start()
    {
        playerPosition = GameObject.Find("FPSCamera");
        pushSpot = GameObject.Find("pushspot");
}

    private void Update()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; // remove constraints
        time ++; //  Increment time
        Physics.IgnoreLayerCollision(8, 10); // Ignore collisions on player layer

        if (this.tag == "Small Cube" || this.tag =="Large Cube") // You can not push small or large cubes
        {
            pushed = false; // set pushed to false
        }

        if (this.tag == "Medium Cube")
        {
            if (!pushed) // When cube is not pushed, make it heavy.
            {
                GetComponent<Rigidbody>().mass = 1000000;
                GetComponent<Rigidbody>().useGravity = true;
            }

            if (pushed)
            {
                GetComponent<Rigidbody>().mass = 1; // Set mass to 1
                GetComponent<Rigidbody>().useGravity = false;              

                Vector3 force = pushSpot.transform.position - this.transform.position; // Set force to difference between target position and current position
                force.y = 0; // Set force on y-axis to zero, since we want to push, not lift

                GetComponent<Rigidbody>().velocity = force.normalized * GetComponent<Rigidbody>().velocity.magnitude; //Set velocity of object to the normalized force, times the length of the current velocity
                GetComponent<Rigidbody>().AddForce(force * pCorrectionForce); // Add correction force
                GetComponent<Rigidbody>().velocity *= Mathf.Min(1.0f, force.magnitude / 2); // Set velocity to the smallest value of either 1 or half the length of force vector. Velocity can not be more than 1

                if (!Collision)
                {
                    transform.parent = null; // remove parent
                    pushed = false; // set pushed to false 
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0); // remove velocity on object
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; // remove constraints
                }

                if ((Input.GetKeyDown("e") || Vector3.Distance(pushSpot.transform.position, transform.position) > 8) && time > 10) // If you press E to release object or is too far away from object
                {
                    transform.parent = null; // remove parent
                    pushed = false; // set pushed to false 
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0); // remove velocity on object
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; // remove constraints
                }
            }         
        }
    }

    void push() // When push message recieved from RayCast.cs
    {
        if (!pushed) // If pushed is not true
        {
            pushed = true; // Set push true
            time = 0; // reset time
        }
    }

    void OnCollisionStay(Collision collision) // When colliding
    {
        if (collision.collider.tag != "Player") // If collider is not player
        {
            Collision = true; // Set colliding true
        }
    }
    void OnCollisionExit() {Collision = false;} // On collision exit, set collision false
}
