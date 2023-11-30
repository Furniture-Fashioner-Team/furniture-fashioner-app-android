using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // reference for ObjectActions component
    private ObjectActions objActions;
    // rotation speed
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
