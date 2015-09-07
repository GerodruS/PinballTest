using System.Collections;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public float force = 10000.0f;

    private HingeJoint hingeJoint;

    protected void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
    }

    protected void FixedUpdate()
    {
        var spring = hingeJoint.spring;

        if (Input.GetButton("Fire1"))
        {
            spring.spring = force;
        }
        else
        {
            spring.spring = 0.0f;
        }

        hingeJoint.spring = spring;
    }
}