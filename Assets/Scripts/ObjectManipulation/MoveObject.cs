using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private ObjectActions objActions; // reference for ObjectActions component
    private float distance = 5; // object's distance from camera (set to static value to keep stable when moving the camera)
    private Vector3 offset = Vector3.zero; // the offset between object and touch position

    // converts the screen position (vector2, xy) to world position (vector3, xyz) by adding distance
    private Vector3 getWorldPosition() 
    { 
        // x and y are derived from currentScreenPosition in ObjectActions
        float currentX = objActions.currentScreenPosition.x;
        float currentY = objActions.currentScreenPosition.y;
        return Camera.main.ScreenToWorldPoint(new Vector3(currentX, currentY, distance));
    }

    private void Start() 
    {
        objActions = GetComponent<ObjectActions>();
    }

    private void Update() 
    {
        if (objActions.isDragged == true) 
        {
            if (offset == Vector3.zero) 
            {
                // calculate offset
                offset = transform.position - getWorldPosition();
            }
            // move object
            transform.position = getWorldPosition() + offset;
        } 
        else 
        {
            // reset offset
            offset = Vector3.zero;
        }
    }
}
