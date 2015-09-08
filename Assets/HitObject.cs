using System.Collections;
using UnityEngine;

public class HitObject : MonoBehaviour
{
    public float bounciness = 1.0f;
    public PhysicMaterialCombine bounceCombine = PhysicMaterialCombine.Average;

    protected void Start()
    {
        SetCollider();
    }

    protected void FixedUpdate()
    {
#if UNITY_EDITOR
        SetCollider();
#endif
    }

    protected void SetCollider()
    {
        var collider = GetComponent<Collider>();
        collider.material.bounciness = bounciness;
        collider.material.bounceCombine = bounceCombine;
        //Debug.Log(collider.material.bounciness);
    }
}