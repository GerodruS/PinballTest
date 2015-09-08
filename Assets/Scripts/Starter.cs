using UnityEngine;

public class Starter : MonoBehaviour
{
    public Rigidbody ball;
    public Transform positionReset;

    public void Reset()
    {
        ball.rotation = Quaternion.identity;
        ball.velocity = Vector3.zero;
        ball.transform.position = positionReset.position;
    }
}