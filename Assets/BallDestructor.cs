using System.Collections;
using UnityEngine;

public class BallDestructor : MonoBehaviour
{
    public string tagDestructor = "Ball";
    public Starter starter;

    protected void OnCollisionEnter(Collision collision)
    {
        Debug.Log(string.Format("OnCollisionEnter {0} {1}", collision.gameObject.name, collision.gameObject.tag));
        if (collision.gameObject.tag == tagDestructor)
        {
            starter.Reset();
        }
    }
}