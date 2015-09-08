using UnityEngine;

public class Ball : MonoBehaviour
{
    public float maxSpeed = 50.0f;

    private Rigidbody rigidbody;

    protected void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    protected void FixedUpdate()
    {
        if (maxSpeed < rigidbody.velocity.magnitude)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }
    }
}