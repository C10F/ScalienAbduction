using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject playerPosition;
    public bool pickedUp = false;
    public float mCorrectionForce = 20.0f;
    public float mPointDistance = 4.0f;

    private void Update()
    {
            if (pickedUp)
            {
                if (GetComponent<Rigidbody>().constraints != RigidbodyConstraints.FreezeRotation)
                {
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                }

                Vector3 targetPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));
                targetPoint += Camera.main.transform.forward * mPointDistance;
                Vector3 force = targetPoint - this.transform.position;

                GetComponent<Rigidbody>().velocity = force.normalized * GetComponent<Rigidbody>().velocity.magnitude;
                GetComponent<Rigidbody>().AddForce(force * mCorrectionForce);

                GetComponent<Rigidbody>().velocity *= Mathf.Min(1.0f, force.magnitude / 2);

                if (Input.GetKeyDown("e") || Vector3.Distance(targetPoint, transform.position) > 8)
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
}
