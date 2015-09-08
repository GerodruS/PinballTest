using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderStarter : MonoBehaviour, IPointerUpHandler
{
    public Rigidbody triggerRigidbody;
    public float force;

    private Slider slider;

    public void OnPointerUp(PointerEventData eventData)
    {
        slider.value = 1.0f;
    }

    protected void Start()
    {
        slider = GetComponent<Slider>();
    }

    protected void FixedUpdate()
    {
        triggerRigidbody.AddForce(Vector3.back * force * (1.0f - slider.value));
    }
}