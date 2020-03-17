using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    public GameObject playerPosition;
    public bool pushed = false;
    public float pCorrectionForce = 5.0f;
    public float pPointDistance = 4.0f;

    public bool Collision = false;

    private void Update()
    {
        if (this.tag == "Small Cube" || this.tag =="Large Cube")
        {
            pushed = false;
        }

        if (this.tag == "Medium Cube")
        {
    
            if (!pushed)
                {
                GetComponent<Rigidbody>().mass = 1000000;
                }
        if (pushed)
        {
                GetComponent<Rigidbody>().mass = 1;
                if (GetComponent<Rigidbody>().constraints != RigidbodyConstraints.FreezeRotation)
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            }

                Vector3 targetPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));
                targetPoint += Camera.main.transform.forward * pPointDistance;
                targetPoint.y = 0;

                    Vector3 force = targetPoint - this.transform.position;
                    force.y = 0;

                    GetComponent<Rigidbody>().velocity = force.normalized * GetComponent<Rigidbody>().velocity.magnitude;
                    GetComponent<Rigidbody>().AddForce(force * pCorrectionForce);

                    GetComponent<Rigidbody>().velocity *= Mathf.Min(1.0f, force.magnitude / 2);
            if (Input.GetKeyDown("f") || Vector3.Distance(targetPoint, transform.position) > 8)
            {
                pushed = false;
                }
        }
        }
        else
        {
            if (!GetComponent<Rigidbody>().useGravity)
            {
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }

        }
    }

    void push()
    {
        if (!pushed)
        {
            pushed = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "Player") {
            Collision = true;
        }
        //Debug.Log("collision happened sir, sorry");
    }
    void OnCollisionExit()
    {
        Collision = false;
        //Debug.Log("collision gone");
    }
}
