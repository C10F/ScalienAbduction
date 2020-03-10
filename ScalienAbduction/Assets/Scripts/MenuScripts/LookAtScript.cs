using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtScript : MonoBehaviour
{

    public GameObject target;
    public float speedModifier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform.position + new Vector3(0.0f, -4.0f, 5.0f));
        transform.RotateAround(target.transform.position, new Vector3(0.0f,0.1f,0.0f), 20 * Time.deltaTime * speedModifier);
        
    }
}
