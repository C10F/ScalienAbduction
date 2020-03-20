using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject playerPosition; // Position of The Player Object
    public GameObject Hold; // Spot where cube should be

    public bool pickedUp = false; // Boolean to track if object is picked up
    public bool Collision = false; // Boolean to track if object is colliding

    public float mCorrectionForce = 20.0f; // Force used to correct path of object back to target position

    public float time; // Float used to set a timer between being able to pick-up and put down items.

    private void Start()
    {
        playerPosition = GameObject.Find("FPSCamera");
        Hold = GameObject.Find("hold");
    }

    private void Update()
    {
        time++; //  Increment time
        Physics.IgnoreLayerCollision(8, 10); // Ignore collisions on player layer

        if (this.tag == "Medium Cube" || this.tag == "Large Cube") // Only small cube can be picked up
        {
            pickedUp = false; // set pickedUp to false
        }

        if (this.tag == "Small Cube") // If tag on object is Small Cube
        {
            if (!pickedUp) // If object is not picked up
            {
                GetComponent<Rigidbody>().mass = 1000000; // Make it heavy
            }
            if (pickedUp) // If object is picked up
            {
                GetComponent<Rigidbody>().useGravity = false; // remove gravity
                GetComponent<Rigidbody>().mass = 1; // Make it light
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation; // Freeze rotation

                if (!Collision) // If object is not colliding
                {
                    transform.position = Hold.transform.position; // Set position of object to hold position
                    transform.parent = playerPosition.transform; // Set parent of object to player
                    transform.rotation = transform.parent.rotation; // Set rotation of object to parent rotation
                }
                if (Collision) // If object is colliding
                {
                    transform.parent = null; // Remove parent

                    Vector3 force = Hold.transform.position - this.transform.position; // Set force to difference between target position and current position

                    GetComponent<Rigidbody>().velocity = force.normalized * GetComponent<Rigidbody>().velocity.magnitude; //Set velocity of object to the normalized force, times the length of the current velocity
                    GetComponent<Rigidbody>().AddForce(force * mCorrectionForce); // Add correction force
                    GetComponent<Rigidbody>().velocity *= Mathf.Min(1.0f, force.magnitude / 2); // Set velocity to the smallest value of either 1 or half the length of force vector. Velocity can not be more than 1
                }

                if ((Input.GetKeyDown("e") || Vector3.Distance(Hold.transform.position, transform.position) > 12) && time > 10) // If you press E to release object or is too far away from object
                {
                    transform.parent = null; // Remove parent
                    pickedUp = false; // Set pickup to false
                    GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0); // Remove velocity on object
                }
            }
            else // If none of the cases are true
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; // Remove constraints
                GetComponent<Rigidbody>().useGravity = true; // Enable gravity
                pickedUp = false; // Set pickedUp false
            }
        }
    }

    void pickUp() // When pickUp message recieved from RayCast.cs
    {
        if (!pickedUp) // If pickedUp is false
        {
            pickedUp = true; // Set it true
            transform.position = Hold.transform.position; // Set position of object to target position
            time = 0; // Reset time
        }
    }

    void OnCollisionStay(Collision collision) // When colliding
    {
        if (collision.collider.tag != "Player") // If collider is not player
        {
            Collision = true; // Set collision true
        }
    }
    void OnCollisionExit() // When no longer colliding
    {
        Collision = false; // Set collision false
    }
}
