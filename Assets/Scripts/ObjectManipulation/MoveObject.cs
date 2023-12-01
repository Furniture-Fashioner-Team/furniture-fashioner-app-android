using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    Handles object moving on xz axis (horizontally). Object's y position comes from initialization.
*/
public class MoveObject : MonoBehaviour
{
    private ObjectActions objActions;
    private float posY;
    // The offset between the object's original place and destination
    private Vector3 offset = Vector3.zero;
    
    /*  Turns screen touch coordinates (xy) to world coordinates (xyz).
        Screen y is converted to world z, and world y is static.
        Touch at bottom of screen: z = 0m, top of screen: z = 3.0m
    */
    private Vector3 WorldPosition()
    { 
        float screenPosX = objActions.currentScreenPosition.x;
        float screenPosY = objActions.currentScreenPosition.y;
        float convertedZ = Mathf.Lerp(0, 3.0f, screenPosY / Screen.height);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(screenPosX, 0, convertedZ));
        return new Vector3(worldPos.x, posY, worldPos.z);
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
                // Calculate offset
                offset = transform.position - WorldPosition();
            }
            // Move object
            transform.position = WorldPosition() + offset;
        } 
        else 
        {
            // Reset offset
            offset = Vector3.zero;
        }
    }
}
