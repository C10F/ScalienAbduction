using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCore : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Rotate(0.2f, 0.5f, 0.2f, Space.Self);

        if (transform.parent.parent.GetComponent<Scaling>().isScaling)
        {
            this.transform.Rotate(1f, 6f, 1f, Space.Self);
        }
        if (transform.parent.parent.GetComponent<doorKeySnap>().snapped)
        {
            this.transform.Rotate(5f, 10f, 5f, Space.Self);
        }
    }
}