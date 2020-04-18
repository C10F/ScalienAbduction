using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStart : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject controlsMenu;
    public Text controlsText;
    public Text backText;

    public void PlayButton(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    public void ControlsButton()
    {
        mainMenu.SetActive(false);
        controlsMenu.SetActive(true);
        controlsText.color = Color.white;
    }

    public void BackButton()
    {
        controlsMenu.SetActive(false);
        mainMenu.SetActive(true);
        backText.color = Color.white;
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
