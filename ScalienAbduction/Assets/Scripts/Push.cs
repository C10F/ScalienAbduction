using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    public GameObject playerPosition;
    public bool pushed = false;
    public float pCorrectionForce = 5.0f;
    public float pPointDistance = 4.0f;

    private void Update()
    {
        if (pushed)
        {
            if (GetComponent<Rigidbody>().constraints != RigidbodyConstraints.FreezeRotation)
            {
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            }

            Vector3 targetPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            targetPoint += Camera.main.transform.forward * pPointDistance;
            Vector3 force = targetPoint - this.transform.position;
            force.y = 0;

            GetComponent<Rigidbody>().velocity = force.normalized * GetComponent<Rigidbody>().velocity.magnitude;
            GetComponent<Rigidbody>().AddForce(force * pCorrectionForce);

            GetComponent<Rigidbody>().velocity *= Mathf.Min(1.0f, force.magnitude / 2);

            if (Input.GetKeyDown("e") || Vector3.Distance(targetPoint, transform.position) > 8)
            {
                pushed = false;
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
}
