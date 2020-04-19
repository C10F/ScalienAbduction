using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorLogicUnlock : MonoBehaviour
{
    public GameObject exitDoorLeft;
    public GameObject exitDoorRight;

    public List<GameObject> floorDiodes = new List<GameObject>();

    public float speed = 5f;
    private float dist;
    private int doorDis = 10; //Door Displacement
    private Vector3 doorDisSpotRightClose;
    private Vector3 doorDisSpotRightOpen;
    private Vector3 doorDisSpotLeftClose;
    private Vector3 doorDisSpotLeftOpen;

    private bool moving = false;
    private bool rightDone = false;
    private bool leftDone = false;
    private bool open = false;

    void Start()
    {
        floorDiodes.AddRange(GameObject.FindGameObjectsWithTag("floorDiode"));
        doorDisSpotRightOpen = exitDoorRight.transform.localPosition - new Vector3(doorDis, 0, 0);
        doorDisSpotRightClose = exitDoorRight.transform.localPosition;
        doorDisSpotLeftOpen = exitDoorLeft.transform.localPosition + new Vector3(doorDis, 0, 0);
        doorDisSpotLeftClose = exitDoorLeft.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(dist > 0) Debug.Log("distance is: " + dist);
        if (!moving)
        {
            if (doorKeySnap.mediumUnlocked == true && doorKeySnap.smallAUnlocked == true && doorKeySnap.smallBUnlocked == true)
            {
                if(!open)
                {
                    Debug.Log("opening door");
                    open = !open;
                    StartCoroutine(TurnOnOffDiodes());
                }
            }
            if (doorKeySnap.mediumUnlocked == false || doorKeySnap.smallAUnlocked == false || doorKeySnap.smallBUnlocked == false)
            {
                if (open)
                {
                    Debug.Log("closing door");
                    //open = !open;
                    open = false;
                    StartCoroutine(TurnOnOffDiodes());
                }
            }
        }
        if (rightDone && leftDone)
        {
            StopCoroutine(RightDoorOpenLock());
            StopCoroutine(LeftDoorOpenLock());
            rightDone = false;
            leftDone = false;
            moving = false;
        }
    }

    IEnumerator TurnOnOffDiodes()
    {
        moving = true;
        for (int i = 0; i < floorDiodes.Count; i++)
        {
            if (open)
            {
                floorDiodes[i].GetComponent<Renderer>().material.SetColor("_Tint", Color.green);
            }
            else
            {
                floorDiodes[i].GetComponent<Renderer>().material.SetColor("_Tint", Color.white);
            }
            
            yield return new WaitForSeconds(0.1f);
            if (i == floorDiodes.Count-1)
            {
                StartCoroutine(RightDoorOpenLock());
                StartCoroutine(LeftDoorOpenLock());
                break;
            }
        }
        while (!rightDone || !leftDone)
        {
            yield return null;
        }
        yield return new WaitForSeconds(3f);

    }

    IEnumerator RightDoorOpenLock()
    {
        if(open)
        {
            while (exitDoorRight.transform.localPosition != doorDisSpotRightOpen)
            {
                if (Vector3.Distance(exitDoorRight.transform.localPosition, doorDisSpotRightOpen) > 0.4 && exitDoorRight.transform.localPosition.x > doorDisSpotRightOpen.x)
                {
                    exitDoorRight.transform.localPosition = Vector3.Lerp(exitDoorRight.transform.localPosition, doorDisSpotRightOpen, Time.deltaTime * speed);
                }
                else exitDoorRight.transform.localPosition = doorDisSpotRightOpen;
                yield return null;
            }
        }
        else
        {
            while (exitDoorRight.transform.localPosition != doorDisSpotRightClose)
            {
                if (Vector3.Distance(exitDoorRight.transform.localPosition, doorDisSpotRightClose) > 0.4 && exitDoorRight.transform.localPosition.x < doorDisSpotRightOpen.x)
                {
                    exitDoorRight.transform.localPosition = Vector3.Lerp(exitDoorRight.transform.localPosition, doorDisSpotRightClose, Time.deltaTime * speed);
                }
                else exitDoorRight.transform.localPosition = doorDisSpotRightClose;
                yield return null;
            }
        }
        Debug.Log("lerp done");
        while (!rightDone || !leftDone)
        {
            if (!rightDone)
            {
                rightDone = true;
            }
            yield return null;
        }
       
        //yield return new WaitForSeconds(1f);
    }

    IEnumerator LeftDoorOpenLock()
    {
        if(open)
        {
            while (exitDoorLeft.transform.localPosition != doorDisSpotLeftOpen)
            {
                if (Vector3.Distance(exitDoorLeft.transform.localPosition, doorDisSpotLeftOpen) > 0.4 && exitDoorLeft.transform.localPosition.x < doorDisSpotLeftOpen.x )
                {
                    exitDoorLeft.transform.localPosition = Vector3.Lerp(exitDoorLeft.transform.localPosition, doorDisSpotLeftOpen, Time.deltaTime * speed);
                }
                else exitDoorLeft.transform.localPosition = doorDisSpotLeftOpen;
                yield return null;
            }
        }
        else
        {
            while (exitDoorLeft.transform.localPosition != doorDisSpotLeftClose)
            {
                if (Vector3.Distance(exitDoorLeft.transform.localPosition, doorDisSpotLeftClose) > 0.4 && exitDoorLeft.transform.localPosition.x > doorDisSpotLeftOpen.x)
                {
                    exitDoorLeft.transform.localPosition = Vector3.Lerp(exitDoorLeft.transform.localPosition, doorDisSpotLeftClose, Time.deltaTime * speed);
                }
                else exitDoorLeft.transform.localPosition = doorDisSpotLeftClose;
                yield return null;
            }
        }
        while (!rightDone || !leftDone)
        {
            if (!leftDone)
            {
                leftDone = true;
            }
            yield return null;
        }
        //yield return new WaitForSeconds(1f);
    }
}
