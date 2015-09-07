using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Starter : MonoBehaviour
{
    public Rigidbody ball;
    public Slider sliderSpeed;

    [Range(0.0f, 10.0f)]
    public float forceMin;

    [Range(0.0f, 10.0f)]
    public float forceDelta;

    private Vector3 positionStart = Vector3.zero;

    public void StartBall(float force)
    {
        Reset();

        ball.AddForce(Vector3.forward * force * sliderSpeed.value);
        Debug.Log("StartBall " + (force * sliderSpeed.value).ToString());
    }

    public void Reset()
    {
        ball.rotation = Quaternion.identity;
        ball.velocity = Vector3.zero;
        ball.transform.position = positionStart;
    }

    protected void Start()
    {
        positionStart = ball.transform.position;
    }
}