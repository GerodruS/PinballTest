using UnityEngine;

public class Starter : MonoBehaviour
{
    public Rigidbody ball;
    public Transform positionReset;
    public string buttonNamePause = "Pause";
    public Pause pause;

    public void Reset()
    {
        ball.rotation = Quaternion.identity;
        ball.velocity = Vector3.zero;
        ball.transform.position = positionReset.position;

        Game.SaveScore(ScoreViewer.GetScore());
        ScoreViewer.ResetScore();
    }

    protected void Update()
    {
        if (Input.GetButtonDown(buttonNamePause))
        {
            pause.SwitchState();
        }
    }
}