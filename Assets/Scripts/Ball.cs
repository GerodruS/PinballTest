using UnityEngine;

public class Ball : MonoBehaviour
{
    public float maxSpeed = 50.0f;

    private Rigidbody thisRigidbody;

    protected void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    protected void FixedUpdate()
    {
        if (maxSpeed < thisRigidbody.velocity.magnitude)
        {
            thisRigidbody.velocity = thisRigidbody.velocity.normalized * maxSpeed;
        }
    }
}