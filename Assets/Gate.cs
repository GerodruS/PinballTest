using System.Collections;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public float force = 10000.0f;

    private HingeJoint hingeJoint;
    private JointSpring jointSpring;
    private Rigidbody rigidbody;

    public void Hit()
    {
        rigidbody.AddForce(Vector3.forward * force);
    }

    protected void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        rigidbody = GetComponent<Rigidbody>();

        jointSpring = new JointSpring();
    }
}