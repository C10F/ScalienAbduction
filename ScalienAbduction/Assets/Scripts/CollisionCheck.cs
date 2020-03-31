using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    new Rigidbody rigidbody;
    public Vector3 position, velocity, angularVelocity;
    public bool isColliding;
    public AudioClip[] dropS;
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

    void OnCollisionEnter(Collision collision) 
    {
        int r = Random.Range(0,3);
        if (collision.collider.tag != "Player") 
        {
            GetComponent<AudioSource>().PlayOneShot(dropS[r]);
        }
    }
}