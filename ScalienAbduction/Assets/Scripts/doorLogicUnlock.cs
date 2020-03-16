using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorLogicUnlock : MonoBehaviour
{
    public GameObject exitDoor;

    public List<GameObject> floorDiodes = new List<GameObject>();

    static bool doorOpen = false;

    public float speed = 1.5f;

    private void Start()
    {
        floorDiodes.AddRange(GameObject.FindGameObjectsWithTag("floorDiode"));
    }

    // Update is called once per frame
    void Update()
    {
        if(doorKeySnap.mediumUnlocked == true && doorKeySnap.smallAUnlocked == true && doorKeySnap.smallBUnlocked == true)
        {
            StartCoroutine(doorLightUp());
            //var cubeRenderer = exitDoor.GetComponent<Renderer>();
            //cubeRenderer.material.SetColor("_Color", Color.green);
        }
    }

    IEnumerator doorLightUp()
    {
        for (int i = 0; i < floorDiodes.Count; i++)
        {
            var cubeRenderer = floorDiodes[i].GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", Color.green);

            yield return new WaitForSeconds(0.1f);

            if (i == floorDiodes.Count-1)
            {
                var doorRenderer = exitDoor.GetComponent<Renderer>();
                doorRenderer.material.SetColor("_Color", Color.green);
                //transform.rotation = Quaternion.Euler(0, 125, 0);

                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 125, 0), Time.deltaTime*speed);
            }
        }
    }
}
