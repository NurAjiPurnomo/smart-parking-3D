using UnityEngine;
using UnityEngine.EventSystems;

public class RightButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("RIGHT TEKAN");
        MobileInput.steer = 1f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("RIGHT LEPAS");
        MobileInput.steer = 0f;
    }
}