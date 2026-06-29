using UnityEngine;
using UnityEngine.EventSystems;

public class GasButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        MobileInput.gas = 1;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        MobileInput.gas = 0;
    }
}