using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChangeCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Player Entered");
        if (collision.gameObject.tag == "Player")
            SceneManager.LoadScene(2);
    }
}
