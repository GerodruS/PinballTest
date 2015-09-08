using UnityEngine;

public class BallDestructor : MonoBehaviour
{
    public event System.Action OnBallDestruct;

    public string tagDestructor = "Ball";
    public Starter starter;

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tagDestructor)
        {
            if (OnBallDestruct != null)
            {
                OnBallDestruct();
            }
            starter.Reset();
        }
    }
}