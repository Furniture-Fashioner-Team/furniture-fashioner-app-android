using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// !!NOT FINAL!!

public class MoveObject : MonoBehaviour
{
    private ObjectActions objActions;
    private float posZ; // object's z coordinate
    private float posY = 1; // object's y coordinate (static value)
    private Vector3 offset = Vector3.zero; // used for moving

    private GameObject plane; // floor plane
    private float floorY; // floor plane's y


    // converts the screen position (vector2, xy) to world position (vector3, xyz)
    private Vector3 WorldPosition() 
    { 
        // x and y are derived from currentScreenPosition in ObjectActions
        float currentX = objActions.currentScreenPosition.x;
        float currentY = objActions.currentScreenPosition.y;
        return Camera.main.ScreenToWorldPoint(new Vector3(currentX, currentY, posZ));
    }

    private void Start() 
    {
        objActions = GetComponent<ObjectActions>();
    }

    private void Update() 
    {
        // FINDING THE FLOOR PLANE AND SETTING Y COORDINATE
        if (plane == null)
        {
            GameObject[] planes;
            planes = GameObject.FindGameObjectsWithTag("floor"); // plane can be found with tag "floor"
            plane = planes[0];
            if (planes != null) {
                floorY = planes[0].transform.position.y + transform.localScale.y / 2; // + half the object's height to put them on top of the floor
                Debug.Log("floor set");
            }
        }

        // MOVING THE OBJECT
        if (objActions.isDragged == true) 
        {
            // moving with detected plane:
            if (plane != null) 
            {
                Vector3 newPos = WorldPosition(); // screen coordinates to world coordinates
                if (offset == Vector3.zero) 
                {
                    offset = transform.position - new Vector3(newPos.x, Mathf.Max(newPos.y, floorY), newPos.z); // Mathf.Max returns whichever coordinate is bigger of the two
                }
                floorY = plane.transform.position.y;
                Debug.Log($"{newPos.y}, {floorY}");
                transform.position = new Vector3(newPos.x, Mathf.Max(newPos.y, floorY), newPos.z) + offset;
            } 
            // moving without detected plane (this is from the original moving script):
            else 
            {
                if (offset == Vector3.zero) 
                {
                    offset = transform.position - WorldPosition();
                }
                transform.position = WorldPosition() + offset;
            }
        } 
        else 
        {
            // reset offset
            offset = Vector3.zero;
            // z is currently only updated when obj is not moving
            posZ = transform.position.z;
        }
    }
}