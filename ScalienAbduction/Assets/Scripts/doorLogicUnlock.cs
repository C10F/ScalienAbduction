using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorLogicUnlock : MonoBehaviour
{
    public GameObject exitDoorLeft;
    public GameObject exitDoorRight;

    public List<GameObject> floorDiodes = new List<GameObject>();

    public float speed = 5f;
    private int doorDis = 10; //Door Displacement
    private Vector3 doorDisSpotRight;
    private Vector3 doorDisSpotLeft;

    private bool moving = false;
    private bool rightDone = false;
    private bool leftDone = false;
    private bool open = false;

    void Start()
    {
        floorDiodes.AddRange(GameObject.FindGameObjectsWithTag("floorDiode"));
    }

    // Update is called once per frame
    void Update()
    {
        if (!moving)
        {
            if (doorKeySnap.mediumUnlocked == true && doorKeySnap.smallAUnlocked == true && doorKeySnap.smallBUnlocked == true)
            {
                if(!open)
                {
                    open = !open;
                    StartCoroutine(TurnOnOffDiodes());
                }
            }
            if (doorKeySnap.mediumUnlocked == false || doorKeySnap.smallAUnlocked == false || doorKeySnap.smallBUnlocked == false)
            {
                if (open)
                {
                    open = !open;
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
            doorDisSpotRight = exitDoorRight.transform.localPosition - new Vector3(doorDis, 0, 0);
            while (exitDoorRight.transform.localPosition != doorDisSpotRight)
            {
                exitDoorRight.transform.localPosition = Vector3.Lerp(exitDoorRight.transform.localPosition, doorDisSpotRight, Time.deltaTime * speed);
                yield return null;
            }
        }
        else
        {
            doorDisSpotRight = exitDoorRight.transform.localPosition + new Vector3(doorDis, 0, 0);
            while (exitDoorRight.transform.localPosition != doorDisSpotRight)
            {
                exitDoorRight.transform.localPosition = Vector3.Lerp(exitDoorRight.transform.localPosition, doorDisSpotRight, Time.deltaTime * speed);
                yield return null;
            }
        }
        while (!rightDone || !leftDone)
        {
            if (!rightDone)
            {
                rightDone = true;
            }
            yield return null;
        }
       
        yield return new WaitForSeconds(3f);
    }

    IEnumerator LeftDoorOpenLock()
    {
        if(open)
        {
            doorDisSpotLeft = exitDoorLeft.transform.localPosition + new Vector3(doorDis, 0, 0);
            while (exitDoorLeft.transform.localPosition != doorDisSpotLeft)
            {
                exitDoorLeft.transform.localPosition = Vector3.Lerp(exitDoorLeft.transform.localPosition, doorDisSpotLeft, Time.deltaTime * speed);
                yield return null;
            }
        }
        else
        {
            doorDisSpotLeft = exitDoorLeft.transform.localPosition - new Vector3(doorDis, 0, 0);
            while (exitDoorLeft.transform.localPosition != doorDisSpotLeft)
            {
                exitDoorLeft.transform.localPosition = Vector3.Lerp(exitDoorLeft.transform.localPosition, doorDisSpotLeft, Time.deltaTime * speed);
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
        yield return new WaitForSeconds(3f);
    }
}
