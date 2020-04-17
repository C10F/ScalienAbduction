using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level4DoorButton : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;

    public List<GameObject> floorDiodes = new List<GameObject>();

    public float speed = 1f;
    private int doorDis = 2; //Door Displacement
    private Vector3 doorDisSpotRight;
    private Vector3 doorDisSpotLeft;

    private bool door1Done = false;
    private bool door2Done = false;

    void Start()
    {
        floorDiodes.AddRange(GameObject.FindGameObjectsWithTag("floorDiode"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            StartCoroutine(TurnOnOffDiodes());
        }

        if (door1Done && door2Done)
        {
            StopCoroutine(door1Unlock());
            StopCoroutine(door2Unlock());
            StopCoroutine(TurnOnOffDiodes());
        }
    }

    IEnumerator TurnOnOffDiodes()
    {
        for (int i = 0; i < floorDiodes.Count; i++)
        {
            floorDiodes[i].GetComponent<Renderer>().material.SetColor("_Tint", Color.green);

            yield return new WaitForSeconds(0.1f);
            if (i == floorDiodes.Count - 1)
            {
                StartCoroutine(door1Unlock());
                StartCoroutine(door2Unlock());
                break;
            }
        }
        while (!door1Done || !door2Done)
        {
            Debug.Log("DiodesWhileLoop");
            yield return null;
        }
        yield return new WaitForSeconds(3f);

    }

    IEnumerator door1Unlock()
    {

        doorDisSpotRight = door1.transform.localPosition - new Vector3(doorDis, 0, 0);
        Debug.Log(doorDisSpotRight);
        while (door1.transform.localPosition != doorDisSpotRight)
        {
            door1.transform.localPosition = Vector3.Lerp(door1.transform.localPosition, doorDisSpotRight, Time.deltaTime * speed);
            yield return null;
        }
        while (!door1Done || !door2Done)
        {
            Debug.Log("Door1UnlockWhileLoop");
            if (!door1Done)
            {
                door1Done = true;
            }
            yield return null;
        }
        yield return new WaitForSeconds(3f);
    }

    IEnumerator door2Unlock()
    {
        doorDisSpotLeft = door2.transform.localPosition - new Vector3(doorDis, 0, 0);
        while (door2.transform.localPosition != doorDisSpotLeft)
        {
            door2.transform.localPosition = Vector3.Lerp(door2.transform.localPosition, doorDisSpotLeft, Time.deltaTime * speed);
            yield return null;
        }
        while (!door1Done || !door2Done)
        {
            Debug.Log("DoorUnlock2WhileLoop");
            if (!door2Done)
            {
                door2Done = true;
            }
            yield return null;
        }
        yield return new WaitForSeconds(3f);
    }
}