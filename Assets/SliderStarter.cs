using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderStarter : MonoBehaviour, IPointerUpHandler
{
    public Rigidbody triggerRigidbody;
    public float force;

    private Slider slider;
    private Vector3 hitterStartPosition;

    protected void Start()
    {
        slider = GetComponent<Slider>();
    }

    protected void FixedUpdate()
    {
        triggerRigidbody.AddForce(Vector3.back * force * (1.0f - slider.value));
    }

    public void OnValueChanged(float value)
    {
        //Debug.Log("OnValueChanged " + value);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        slider.value = 1.0f;
    }
}