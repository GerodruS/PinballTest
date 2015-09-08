using System.Collections;
using UnityEngine;

public class HitObject : MonoBehaviour
{
    [Header("Settings")]
    public float force = 100.0f;
    public int score = 10;

    [Header("Scale Animation Parameters")]
    public float scale = 0.8f;
    public float time = 0.5f;

    private bool scaleLock = false;

    protected void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.AddExplosionForce(force, this.transform.position, 0.0f);
        ScoreViewer.ScoreChange(score);
        StartCoroutine(ScaleAnimation());
    }

    protected IEnumerator ScaleAnimation()
    {
        if (!scaleLock)
        {
            scaleLock = true;
            var scaleFinish = transform.localScale;
            var scaleStart = scaleFinish * scale;
            float t = 0.0f;
            while (t < 1.0f)
            {
                transform.localScale = Vector3.Lerp(scaleStart, scaleFinish, t);
                t += Time.deltaTime / time;
                yield return null;
            }
            transform.localScale = scaleFinish;
            scaleLock = false;
        }
    }
}