using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorLogicUnlock : MonoBehaviour
{
    public GameObject exitDoor;

    public List<GameObject> floorDiodes = new List<GameObject>();

    static bool doorOpen = false;

    public float speed = 1.5f;

    void Start()
    {
        floorDiodes.AddRange(GameObject.FindGameObjectsWithTag("floorDiode"));
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(doorKeySnap.mediumUnlocked == true && doorKeySnap.smallAUnlocked == true && doorKeySnap.smallBUnlocked == true)
        {
            StartCoroutine(doorLightUp());
            doorOpen = true;
        }
        if (doorKeySnap.mediumUnlocked == false || doorKeySnap.smallAUnlocked == false || doorKeySnap.smallBUnlocked == false)
        {
            StartCoroutine(doorLockUp());
            doorOpen = false;
        }
    }

    IEnumerator doorLightUp()
    {
        for (int i = 0; i < floorDiodes.Count; i++)
        {
            var cubeRenderer = floorDiodes[i].GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_BaseColor", Color.green);

            yield return new WaitForSeconds(0.1f);

            if (i == floorDiodes.Count-1)
            {
                var doorRenderer = exitDoor.GetComponent<Renderer>();
                doorRenderer.material.SetColor("_BaseColor", Color.green);

                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, 125, 0), Time.deltaTime*speed);
            }
        }
    }

    IEnumerator doorLockUp()
    {
        for (int i = 0; i < floorDiodes.Count; i++)
        {
            var cubeRenderer = floorDiodes[i].GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_BaseColor", Color.grey);

            yield return new WaitForSeconds(0.1f);

            if (i == floorDiodes.Count - 1)
            {
                var doorRenderer = exitDoor.GetComponent<Renderer>();
                doorRenderer.material.SetColor("_BaseColor", Color.red);

                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * speed);
            }
        }
    }
}
