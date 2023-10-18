using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveAndRotateObject : MonoBehaviour
{
    private Color objColor = Color.white; // object's color (for seeing which action is activated)
    [SerializeField] private InputAction press, screenPosition, doublePress, axis; // input system actions
    private Vector3 currentScreenPosition; // position of the screen touch
    private Vector2 rotation; // for axis
    private bool isDragged;
    private bool isRotated;
    private float speed = 0.3f; // rotation speed
    private Vector3 worldPosition { 
        get{
            // adds the distance between camera and object as z because the initial screenPosition is only xy
            float distance = Camera.main.WorldToScreenPoint(transform.position).z;
            return Camera.main.ScreenToWorldPoint(currentScreenPosition + new Vector3(0, 0, distance));
        }
    }
    // checks if screen touch hits an object and returns true/false accordingly
    private bool isActive {
        get{
            Ray ray = Camera.main.ScreenPointToRay(currentScreenPosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                return hit.transform == transform; // returns true if the hit object's transform matches an object the script is attached to
            } else {
                return false;
            }
        }
    }

    // setup tasks
    private void Awake() {
        screenPosition.Enable();
        press.Enable();
        doublePress.Enable();
        axis.Enable();
        // touch position
        screenPosition.performed += context => {currentScreenPosition = context.ReadValue<Vector2>();};
        // 2nd finger touch
        doublePress.performed += _ => {if (isActive) StartCoroutine(Rotate());}; // initiates Rotate()
        doublePress.canceled += _ => {
            isRotated = false; 
            objColor = Color.white;
        };
        // normal touch
        press.performed += _ => {if (isActive && !isRotated) StartCoroutine(Drag());}; // initiates Drag()
        press.canceled += _ => {
            isDragged = false; 
            isRotated = false; 
            objColor = Color.white;
        };
        // axis
        axis.performed += context => {rotation = context.ReadValue<Vector2>(); };
    }

    // coroutine for moving the object
    private IEnumerator Drag() {
        // grabbing
        isDragged = true;
        objColor = Color.blue; // turns blue when dragging is activated
        Vector3 offset = transform.position - worldPosition;
        while(isDragged) {
            // dragging
            transform.position = worldPosition + offset;
            yield return null;
        }
    }

    // coroutine for rotating the object
	private IEnumerator Rotate()
	{
		isRotated = true;
        isDragged = false; // set to false to stop moving
        objColor = Color.green; // turns green when rotating is activated
		while(isRotated)
		{
			rotation = speed * rotation;
			transform.Rotate(Vector3.up * -1, rotation.x, Space.World); // -1 to invert rotation
			yield return null;
		}
	}

    void Update() {
        // renders the object color
        GetComponent<MeshRenderer>().material.color = objColor;
    }
}