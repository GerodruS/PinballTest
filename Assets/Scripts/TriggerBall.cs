using System.Collections;
using UnityEngine;

public class TriggerBall : MonoBehaviour
{
    public event System.Action OnBallReady;

    protected void OnCollisionEnter(Collision collision)
    {
        if ("Ball" == collision.gameObject.tag)
        {
            if (OnBallReady != null)
            {
                OnBallReady();
            }
        }
    }
}