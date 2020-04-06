using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    new Rigidbody rigidbody;
    public Vector3 position, velocity, angularVelocity;
    public bool isColliding;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
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

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Player")
            isColliding = true;
        //.Log("Colliding");
    }   
}