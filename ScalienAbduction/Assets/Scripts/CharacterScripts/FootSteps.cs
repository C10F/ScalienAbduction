using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    AudioSource aSource;
    public GameObject aMgr;
    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LandOnGroundSound()
    {  
        aSource.PlayOneShot(aMgr.GetComponent<AudioClips>().clipType3[1], 0.2f);       
    }
}
