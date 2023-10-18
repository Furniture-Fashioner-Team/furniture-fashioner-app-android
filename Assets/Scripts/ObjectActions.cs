using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// manages the touch input actions to move and rotate an object and open object's tap menu

public class ObjectActions : MonoBehaviour
{
    // input actions
    [SerializeField] private InputAction 
        press, // active until released
        tap, // quick tap
        doublePress, // two fingers
        screenPosition, // touch position on screen
        axis; // axis for rotation

    public Vector2 currentScreenPosition; // screen touch coordinates (xy)
    public Vector2 rotation; // the amount of rotation
    
    // sets the object active upon touch
    public bool isActive {
        get {
            // raycast for checking if the touch hits an object in the view
            Ray ray = Camera.main.ScreenPointToRay(currentScreenPosition);
            RaycastHit hit;
            // any object is found
            if (Physics.Raycast(ray, out hit)) {
                // compares the transform of the found object to the script's transform 
                // (= if they match, the object has this script and can be set active)
                if (hit.transform == transform) {
                    return true;
                // an object without this script is found
                } else {
                    return false;
                }
            // no object is found
            } else {
                return false;
            }
        }
    }
    
    public bool isDragged = false;
    public bool isRotated = false;
    public bool openMenu = false;

    // setup tasks
    private void Awake() {
        screenPosition.Enable();
        axis.Enable();
        press.Enable();
        tap.Enable();
        doublePress.Enable();

        // touch position
        screenPosition.performed += context => {
            currentScreenPosition = context.ReadValue<Vector2>();
        };
        // axis
        axis.performed += context => {
            rotation = context.ReadValue<Vector2>();
        };

        // press until released: activates dragging
        press.performed += _ => {
            if (isActive) {
                isDragged = true;
            }
        };
        press.canceled += _ => {
            isDragged = false;
            isRotated = false;
        };

        // tap: activates an object-specific menu, deactivates when tapped anywhere else
        tap.performed += _ => {
            if (isActive) {
                openMenu = true;
            } else {
                openMenu = false;
            }
        };
        tap.canceled += _ => {
            openMenu = false;
        };

        // 2nd finger press: activates rotating
        doublePress.performed += _ => {
            if (isActive) {
                isRotated = true;
                isDragged = false;
            }
        };
        doublePress.canceled += _ => {
            isRotated = false;
        };
    }
}
