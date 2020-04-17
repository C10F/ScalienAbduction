using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorButton : MonoBehaviour
{
    public GameObject button;

    public void OpenDoor()
    {
        button.SendMessage("TurnOnOffDiodes");
    }

}
