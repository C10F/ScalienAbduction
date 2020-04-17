using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChangeCollider : MonoBehaviour
{

    public GameObject SceneChanger;
    //public GameObject exitDoor;


    private void Start()
    {
        SceneChanger = GameObject.Find("SceneFade"); 
    }
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Player Entered");
        if (collision.gameObject.tag == "Player")
            SceneChanger.SendMessage("FadeToLevel");
    }
}
