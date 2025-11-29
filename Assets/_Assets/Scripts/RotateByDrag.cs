using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class RotateByDrag : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public float sensitivity;
    public float currentYaw, currentPitch;

    private Vector2 startPos, delta;

    public void OnPointerDown(PointerEventData eventData)
    {
        startPos = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        currentPitch = 0;
        currentYaw = 0;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        delta = (eventData.position - startPos).normalized;
        UpdateYaw();
        UpdatePitch();
    }

    private void UpdatePitch()
    {
        float deltaPitch = delta.y;
        currentPitch = deltaPitch * sensitivity;
    }

    void UpdateYaw()
    {
        float deltaYaw = delta.x;
        currentYaw = deltaYaw * sensitivity;
    }
}
