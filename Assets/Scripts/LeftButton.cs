using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        MobileInput.steer = -1;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        MobileInput.steer = 0;
    }
}