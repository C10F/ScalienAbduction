using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorKeySnap : MonoBehaviour
{
    bool snapped = false;
    GameObject snapparent;
    Vector3 offset;
    //public GameObject preasurePlate;
    GameObject mediumPreasurePlateRim;
    GameObject smallPreasurePlateRimA;
    GameObject smallPreasurePlateRimB;
    public static bool mediumUnlocked = false;
    public static bool smallAUnlocked = false;
    public static bool smallBUnlocked = false;

    private void Start()
    {
        mediumPreasurePlateRim = GameObject.FindGameObjectWithTag("mediumPreasurePlateRim");
        smallPreasurePlateRimA = GameObject.FindGameObjectWithTag("smallPreasurePlateRimA");
        smallPreasurePlateRimB = GameObject.FindGameObjectWithTag("smallPreasurePlateRimB");
    }

    // Update is called once per frame
    void Update()
    {
        if (snapped == true)
        {
            //transform.position = preasurePlate.transform.position + offset;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "mediumPreasurePlate" && other.isTrigger && gameObject.tag == "Medium Cube")
        {
            //snapped = true;
            //snapparent = other.gameObject;
            //offset = transform.position - snapparent.transform.position; //store relation to parent
            var cubeRenderer = mediumPreasurePlateRim.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.green);
            mediumUnlocked = true;
        }

        if (other.tag == "smallPreasurePlateA" && other.isTrigger && gameObject.tag == "Small Cube")
        {
            //snapped = true;
            //snapparent = other.gameObject;
            //offset = transform.position - snapparent.transform.position; //store relation to parent
            var cubeRenderer = smallPreasurePlateRimA.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.green);
            smallAUnlocked = true;
        }
        if (other.tag == "smallPreasurePlateB" && other.isTrigger && gameObject.tag == "Small Cube")
        {
            //snapped = true;
            //snapparent = other.gameObject;
            //offset = transform.position - snapparent.transform.position; //store relation to parent
            var cubeRenderer = smallPreasurePlateRimB.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.green);
            smallBUnlocked = true;
        }
    }
}
