using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 15f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    public bool isGrounded;
    bool hasJumped = false;
    bool isSprinting;
    float oldBobAmount;
    float oldBobSpeed;
    void Awake() 
    {
        oldBobAmount = GetComponentInChildren<Camera>().GetComponent<HeadBob>().bobAmount;
        oldBobSpeed = GetComponentInChildren<Camera>().GetComponent<HeadBob>().bobSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (!isGrounded) hasJumped = true;
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            if(controller.slopeLimit != 45) controller.slopeLimit = 45;
            if(hasJumped)GameObject.Find("GroundCheck").SendMessage("LandOnGroundSound"); hasJumped = false;

        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * (x * 0.75f)  + transform.forward * z;
        if (Input.GetKey(KeyCode.LeftShift)) isSprinting = true;
        else isSprinting = false;

        if (isSprinting)
        {
            controller.Move(move * (speed * 1.5f) * Time.deltaTime);

            GetComponentInChildren<Camera>().GetComponent<HeadBob>().bobAmount = oldBobAmount + 0.1f;
            GetComponentInChildren<Camera>().GetComponent<HeadBob>().bobSpeed = oldBobSpeed + 0.5f;

        }
        else if (GetComponentInChildren<HeadBob>().crouched) 
        {
            controller.Move(move * (speed * 0.4f) * Time.deltaTime);
            GetComponentInChildren<Camera>().GetComponent<HeadBob>().bobAmount = oldBobAmount - 0.05f;
        }
        else { controller.Move(move * speed * Time.deltaTime); GetComponentInChildren<Camera>().GetComponent<HeadBob>().bobAmount = oldBobAmount; GetComponentInChildren<Camera>().GetComponent<HeadBob>().bobSpeed = oldBobSpeed; }



        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            controller.slopeLimit = 90;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        // REMOVE LATER
        if (Input.GetKeyUp(KeyCode.Escape)) Application.Quit();
    }
    void FixedUpdate() 
    {
        
    }

}
