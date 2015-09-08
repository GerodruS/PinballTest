using UnityEngine;

public class Gate : MonoBehaviour
{
    public float force = 10000.0f;
    public string buttonName = "HitLeft";

    private enum State
    {
        None,
        Hit,
        Reset
    }

    private HingeJoint thisHingeJoint;
    private State state = State.None;

    public void SetHit()
    {
        state = State.Hit;
    }

    protected void Start()
    {
        thisHingeJoint = GetComponent<HingeJoint>();
    }

    protected void Update()
    {
        if (Input.GetButtonDown(buttonName))
        {
            SetHit();
        }
    }

    protected void FixedUpdate()
    {
        switch (state)
        {
            case State.Hit:
                {
                    var spring = thisHingeJoint.spring;
                    spring.spring = force;
                    thisHingeJoint.spring = spring;

                    state = State.Reset;
                }
                break;

            case State.Reset:
                {
                    var spring = thisHingeJoint.spring;
                    spring.spring = 0.0f;
                    thisHingeJoint.spring = spring;

                    state = State.None;
                }
                break;

            default:
                break;
        }
    }
}