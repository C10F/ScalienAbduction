using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject playerPosition;
    public bool pickedUp = false;
    public float mCorrectionForce = 20.0f;
    public float mPointDistance = 4.0f;
    public bool Collision = false;

    private void Update()
    {
        if (this.tag == "Medium Cube" || this.tag == "Large Cube")
        {
            pickedUp = false;
        }
        if (this.tag == "Small Cube")
        {
            if (!pickedUp)
            {
                GetComponent<Rigidbody>().mass = 1000000;
            }
            if (pickedUp)
            {
                GetComponent<Rigidbody>().mass = 1;
                if (GetComponent<Rigidbody>().constraints != RigidbodyConstraints.FreezeRotation)
                {
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                }

                Vector3 targetPoint = playerPosition.transform.position;
                targetPoint += playerPosition.transform.forward * mPointDistance;
                if (!Collision)
                {
                    transform.position = targetPoint;
                }
                if (Collision){
                    Vector3 force = targetPoint - this.transform.position;

                    GetComponent<Rigidbody>().velocity = force.normalized * GetComponent<Rigidbody>().velocity.magnitude;
                    GetComponent<Rigidbody>().AddForce(force * mCorrectionForce);

                    GetComponent<Rigidbody>().velocity *= Mathf.Min(1.0f, force.magnitude / 2);
                }

                if (Input.GetKeyDown("e") || Vector3.Distance(targetPoint, transform.position) > 12)
                {
                    pickedUp = false;
                }
            }
            else
            {
                if (!GetComponent<Rigidbody>().useGravity)
                {
                    GetComponent<Rigidbody>().useGravity = true;
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    pickedUp = false;
                }

            }
        }

    }

    void pickUp()
    {
        if (!pickedUp)
        {
            pickedUp = true;
        }
    }

    void OnCollisionEnter()
    {
        Collision = true;
        Debug.Log("collision happened sir, sorry");
    }
    void OnCollisionExit()
    {
        Collision = false;
        Debug.Log("collision gone");
    }
}
