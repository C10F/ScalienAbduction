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

        mediumUnlocked = false;
        smallAUnlocked = false;
        smallBUnlocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (snapped == true)
        {
            //transform.position = preasurePlate.transform.position + offset;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "mediumPreasurePlate" && other.isTrigger && (gameObject.tag == "Small Cube" || gameObject.tag == "Medium Cube" || gameObject.tag == "Large Cube"))
        {
            var cubeRenderer = mediumPreasurePlateRim.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_BaseColor", Color.red);
            mediumUnlocked = false;
        }

        if (other.tag == "smallPreasurePlateA" && other.isTrigger && (gameObject.tag == "Small Cube" || gameObject.tag == "Medium Cube" || gameObject.tag == "Large Cube"))
        {
            var cubeRenderer = smallPreasurePlateRimA.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_BaseColor", Color.red);
            smallAUnlocked = false;
        }
        if (other.tag == "smallPreasurePlateB" && other.isTrigger && (gameObject.tag == "Small Cube" || gameObject.tag == "Medium Cube" || gameObject.tag == "Large Cube"))
        {
            var cubeRenderer = smallPreasurePlateRimB.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_BaseColor", Color.red);
            smallBUnlocked = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "mediumPreasurePlate" && other.isTrigger && gameObject.tag == "Medium Cube" && this.GetComponent<PickUp>().pickedUp == false)
        {
            //snapped = true;
            //snapparent = other.gameObject;
            //offset = transform.position - snapparent.transform.position; //store relation to parent
            var cubeRenderer = mediumPreasurePlateRim.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_BaseColor", Color.green);
            mediumUnlocked = true;
        }

        if (other.tag == "smallPreasurePlateA" && other.isTrigger && gameObject.tag == "Small Cube" && this.GetComponent<PickUp>().pickedUp == false)
        {
            var cubeRenderer = smallPreasurePlateRimA.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_BaseColor", Color.green);
            smallAUnlocked = true;
        }
        if (other.tag == "smallPreasurePlateB" && other.isTrigger && gameObject.tag == "Small Cube" && this.GetComponent<PickUp>().pickedUp == false)
        {
            var cubeRenderer = smallPreasurePlateRimB.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_BaseColor", Color.green);
            smallBUnlocked = true;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////

        if (other.tag == "mediumPreasurePlate" && other.isTrigger && (gameObject.tag == "Small Cube" || gameObject.tag == "Large Cube") && this.GetComponent<PickUp>().pickedUp == false)
        {
            var cubeRenderer = mediumPreasurePlateRim.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_BaseColor", Color.red);
            mediumUnlocked = false;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////

        if (other.tag == "smallPreasurePlateA" && other.isTrigger && (gameObject.tag == "Medium Cube" || gameObject.tag == "Large Cube") && this.GetComponent<PickUp>().pickedUp == false)
        {
            var cubeRenderer = smallPreasurePlateRimA.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_BaseColor", Color.red);
            smallAUnlocked = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "smallPreasurePlateA" || other.tag == "smallPreasurePlateB" || other.tag == "mediumPreasurePlate")
        {
            if (this.GetComponent<PickUp>().pickedUp == false)
            {
                Vector3 platePos = other.transform.position;
                this.transform.localPosition = platePos;

                Quaternion plateRot = other.transform.rotation;
                this.transform.localRotation = plateRot;
            }
        }
    }
}
