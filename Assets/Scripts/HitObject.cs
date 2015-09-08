using UnityEngine;

public class HitObject : MonoBehaviour
{
    public float force = 100.0f;
    public int score = 10;

    protected void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.AddExplosionForce(force, this.transform.position, 0.0f);
        ScoreViewer.ScoreChange(score);
    }
}