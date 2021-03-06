﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{

    public Vector3 restPosition; //local position where your camera would rest when it's not bobbing.
    public float transitionSpeed = 20f; //smooths out the transition from moving to not moving.
    public float bobSpeed = 4.8f; //how quickly the player's head bobs.
    public float bobAmount = 0.05f; //how dramatic the bob is. Increasing this in conjunction with bobSpeed gives a nice effect for sprinting.
    public bool LtRf;
    public float stepT = 0.06f;
    public bool crouched = false;
    bool hasPlayed, hasPlayed2;
    bool isGrounded;
    float timer = Mathf.PI / 2; //initialized as this value because this is where sin = 1. 
    Vector3 camPos;
    public GameObject SoundMgr;
    public AudioSource audio;
    AudioClip[] steps;
    AudioClip[] jumps;
    //public AudioClip step1, step2, step3;
    
    void Awake()
    {
        camPos = transform.localPosition;
        audio = gameObject.GetComponent<AudioSource>();
        steps = SoundMgr.GetComponent<AudioClips>().clipType2;
        jumps = SoundMgr.GetComponent<AudioClips>().clipType1;
    }

    void Update()
    {

        isGrounded = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().isGrounded;

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) //moving
        {
            

            //use the timer value to set the position
            //Vector3 newPosition = new Vector3(Mathf.Cos(timer) * (bobAmount * 0.35f), restPosition.y + Mathf.Abs((Mathf.Sin(timer) * Mathf.Lerp(0,bobAmount,transitionSpeed * Time.deltaTime))), restPosition.z); //abs val of y for a parabolic path (after lerp maybe not so much)
            Vector3 newPosition = new Vector3(Mathf.Cos(timer) * (bobAmount * 0.35f), restPosition.y + Mathf.Abs((Mathf.Sin(timer) * bobAmount)), restPosition.z); // little issue here with the start point.. try updating timer after this is called.
            timer += bobSpeed * Time.deltaTime;
            camPos = newPosition;
        }
        else
        {
            timer = Mathf.PI / 2; //reinitialize

            Vector3 newPosition = new Vector3(Mathf.Lerp(camPos.x, restPosition.x, transitionSpeed * Time.deltaTime), Mathf.Lerp(camPos.y, restPosition.y, transitionSpeed * Time.deltaTime), Mathf.Lerp(camPos.z, restPosition.z, transitionSpeed * Time.deltaTime)); //transition smoothly from walking to stopping.
            camPos = newPosition;
        }

        if (timer > Mathf.PI * 2) //completed a full cycle on the unit circle. Reset to 0 to avoid bloated values.
            timer = 0;
        LtRf = false;
        float stepTime = Mathf.Sin(timer) * bobAmount;

        // FOR JUMPING
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            int i = Random.Range(0, jumps.Length - 1);
            audio.PlayOneShot(jumps[i], 1f);
        }
        // FOR FOOTSTEPS
        else if (Input.GetAxisRaw("Horizontal") != 0 && isGrounded || Input.GetAxisRaw("Vertical") != 0 && isGrounded)
        {
            if (stepTime < -stepT || stepTime > stepT)
            {
                LtRf = true;
                if (!hasPlayed)
                {
                    int i = Random.Range(0, steps.Length-1);
                    audio.PlayOneShot(steps[i], 0.1f);
                    hasPlayed = true;
                }
            }
            else { LtRf = false; hasPlayed = false; }
        }

        // FOR CROUCH

        
        if (Input.GetKey(KeyCode.LeftControl))
        {
             crouched = true;
        }
        else { crouched = false; }

    }

    void FixedUpdate()
    {
        if (crouched)
        {
            transform.localPosition = camPos + new Vector3(0f, -0.8f, 0f);
        }
        else transform.localPosition = camPos;  // apply camPos at the end of each frame.    
    }
}