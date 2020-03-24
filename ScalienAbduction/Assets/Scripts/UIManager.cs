using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public Button bStart, bSettings, bExit;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        bStart.onClick.AddListener(() => ChangeScene(1));
        bSettings.onClick.AddListener(() => ChangeScene(0));
        bExit.onClick.AddListener(QuitApplication);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void ChangeScene(int scene) 
    {
        switch (scene) 
        {
            case 0:
                Debug.Log("opening settings..");
                SceneManager.LoadScene("baseScene");
                break;
            case 1:
                Debug.Log("scene change pending..");
                SceneManager.LoadScene("playtest_tutorial");
                break;
            default:
                break;
        }
    }
    void QuitApplication() 
    {
        Debug.Log("quitting..");
        Application.Quit();
    }
}
