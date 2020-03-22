using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChangeCollider : MonoBehaviour
{
    public string scene;
    public GameObject exitDoor;
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Player Entered");
        if (collision.gameObject.tag == "Player")
            exitDoor.GetComponent<doorLogicUnlock>().StartCoroutine("doorLockUp");
            SceneManager.LoadScene(scene);
    }
}
