using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    new Rigidbody rigidbody;
    public bool isColliding;
    public bool touchGround = true;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (touchGround == false)
        {
            this.rigidbody.velocity = new Vector3(0, -5, 0);
            this.rigidbody.angularVelocity = new Vector3 (0,0,0);
        }
    }

    void FixedUpdate()
    {
        if (!isColliding)
        {
            rigidbody.isKinematic = false;
        }
        isColliding = false;
    }

    void LateUpdate()
    {
        if (isColliding)
        {
            rigidbody.isKinematic = true;
        }
        else
        {
            rigidbody.isKinematic = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.gameObject.layer);
        if (collision.collider.gameObject.layer == 8)
        {
            touchGround = true;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Player" && touchGround == true)
            isColliding = true;
        //.Log("Colliding");
    }   
}