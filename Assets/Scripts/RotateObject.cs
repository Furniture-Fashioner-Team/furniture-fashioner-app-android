using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private ObjectActions objActions; // reference for ObjectActions component
    private float speed = 0.3f; // rotation speed
    
    private void Start() {
        objActions = GetComponent<ObjectActions>();
    }

    private void Update() {
        Vector2 rotation = objActions.rotation;
        if (objActions.isRotated == true) {
            rotation = speed * rotation;
			transform.Rotate(Vector3.up * -1, rotation.x, Space.World); // -1 to invert rotation
        }
    }
}
