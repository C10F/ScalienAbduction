using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotate : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        CameraRotater();
    }

    void CameraRotater()
    {
        transform.Rotate(Vector3.up, 10.0f * Time.deltaTime);
    }
}
