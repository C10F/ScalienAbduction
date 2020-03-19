using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropButton : MonoBehaviour
{
    public GameObject[] cubesToDrop;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DropCubes()
    {
        Color oldCol = gameObject.GetComponent<Renderer>().material.GetColor("_Color");
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        for (int i = 0; i < cubesToDrop.Length; i++)
        {
            cubesToDrop[i].GetComponent<Rigidbody>().constraints = 0;
        }
        //yield return new WaitForSeconds(5);
        //gameObject.GetComponent<Renderer>().material.SetColor("_Color", oldCol);
        StartCoroutine(ChangeCol(oldCol, 5, gameObject));
        
    }

    IEnumerator ChangeCol(Color now, int time, GameObject target) 
    {
        yield return new WaitForSeconds(time);
        target.GetComponent<Renderer>().material.SetColor("_Color", now);
    }
}
