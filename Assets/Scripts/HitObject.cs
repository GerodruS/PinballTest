using UnityEngine;

public class HitObject : MonoBehaviour
{
    public float force = 100.0f;

    protected void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.AddExplosionForce(force, this.transform.position, 0.0f);
    }
}