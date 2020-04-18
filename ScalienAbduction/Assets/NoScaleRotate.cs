using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoScaleRotate : MonoBehaviour
{
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        transform.parent = null;
        this.transform.localScale = new Vector3(parent.transform.localScale.x, 100f, parent.transform.localScale.z);
        transform.parent = parent.transform;
    }
}
