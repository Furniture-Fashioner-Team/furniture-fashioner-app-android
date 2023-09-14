using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;

    private void OnMouseDown()
    {
        // Calculate the offset between the object's position and the touch position
        offset = transform.position - GetTouchWorldPos();
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private Vector3 GetTouchWorldPos()
    {
        // Get the touch position in screen space
        Vector3 touchScreenPos = Input.mousePosition;

        // Convert the screen position to world space
        return Camera.main.ScreenToWorldPoint(touchScreenPos);
    }

    private void Update()
    {
        if (isDragging)
        {
            // Update the object's position based on the touch position and offset
            Vector3 touchWorldPos = GetTouchWorldPos();
            transform.position = new Vector3(touchWorldPos.x + offset.x, touchWorldPos.y + offset.y, transform.position.z);
        }
    }
}