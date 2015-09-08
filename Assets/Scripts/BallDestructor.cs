using UnityEngine;

public class BallDestructor : MonoBehaviour
{
    public string tagDestructor = "Ball";
    public Starter starter;

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tagDestructor)
        {
            starter.Reset();
        }
    }
}