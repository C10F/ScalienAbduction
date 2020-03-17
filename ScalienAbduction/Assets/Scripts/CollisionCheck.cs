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
    }

    void LateUpdate()
    {
        if (isColliding)
        {
            rigidbody.isKinematic = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
            isColliding = true;
        //Debug.Log("Colliding");
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
            isColliding = false;
    }
}