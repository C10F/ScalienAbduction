using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public string SceneToLoad;

    public Animator animator;

    // Start is called before the first frame update

    // Update is called once per frame


    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
