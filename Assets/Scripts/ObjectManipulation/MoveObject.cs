using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private ObjectActions objActions; // reference for ObjectActions component
    private float posZ; // object's z coordinate
    private Vector3 offset = Vector3.zero; // the offset between object and touch position
    private TMPro.TMP_Text objectLog; // for testing
    private GameObject plane; // floor plane
    private float floorY;


    // converts the screen position (vector2, xy) to world position (vector3, xyz) by adding distance
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
        objectLog = GameObject.Find("Object Log").GetComponent<TMPro.TMP_Text>();
        plane = GameObject.Find("Plane");
    }

    private void Update() 
    {
        if (objActions.isDragged == true) 
        {
            if (objectLog != null) 
            {
                objectLog.text = $"floor Y: {floorY}";
            }
            // move object
            if (plane != null) 
            {
                Vector3 newPos = WorldPosition();
                if (offset == Vector3.zero) 
                {
                    offset = transform.position - new Vector3(newPos.x, Mathf.Max(newPos.y, floorY+transform.localScale.y), newPos.z);
                }
                floorY = plane.transform.position.y;
                transform.position = new Vector3(newPos.x, Mathf.Max(newPos.y, floorY+transform.localScale.y), newPos.z) + offset; // Mathf.Max returns whichever coordinate is bigger of the two
            } 
            else 
            {
                if (offset == Vector3.zero) 
                {
                    offset = transform.position - WorldPosition();
                }
                transform.position = WorldPosition() + offset;
            }
            // todo: fix transform.rotation relative to camera
            
            /* faces camera but doesn't keep rotation:
            Vector3 lookAtPos = Camera.main.transform.position;
            lookAtPos.y = transform.position.y;
            transform.LookAt(lookAtPos);
            */
            
        } 
        else 
        {
            // reset offset
            offset = Vector3.zero;
            // object's z coordinate is only updated when it's not moving
            posZ = transform.position.z;
        }
    }
}