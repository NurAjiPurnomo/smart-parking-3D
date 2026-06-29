using UnityEngine;
using UnityEngine.EventSystems;

public class BrakeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        MobileInput.brake = 1;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        MobileInput.brake = 0;
    }
}