using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    This script handles rotating the object around y axis.
*/
public class RotateObject : MonoBehaviour
{
    private ObjectActions objActions;
    // Rotation speed
    private float speed = 0.3f;
    
    private void Start() 
    {
        objActions = GetComponent<ObjectActions>();
    }

    private void Update() 
    {
        Vector2 rotation = objActions.rotation;
        if (objActions != null && objActions.isRotated == true) 
        {
            rotation = speed * rotation;
            // -1 to invert rotation
			transform.Rotate(Vector3.up * -1, rotation.x, Space.World);
        }
    }
}
