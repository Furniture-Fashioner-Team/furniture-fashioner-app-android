using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// manages the touch input actions to move and rotate an object and open object's tap menu
public class ObjectActions : MonoBehaviour
{
    // input actions
    private InputAction screenPosition;
    private InputAction axis;
    private InputAction press;
    private InputAction tap;
    private InputAction doublePress;
    public Vector2 currentScreenPosition;
    public Vector2 rotation;
    public bool isDragged = false;
    public bool isRotated = false;
    public bool openMenu = false;

    // setup tasks
    private void Awake()
    {
        screenPosition = new InputAction("scrPos", binding: "<Touchscreen>/position");
        screenPosition.Enable();
        axis = new InputAction("axis", binding: "<Touchscreen>/delta");
        axis.Enable();
        press = new InputAction("press", binding: "<Touchscreen>/press");
        press.Enable();
        tap = new InputAction("tap", binding: "<Touchscreen>/primaryTouch/tap", interactions: "tap");
        tap.Enable();
        doublePress = new InputAction("dblPress", binding: "<Touchscreen>/touch1/press");
        doublePress.Enable();

        // touch position
        screenPosition.performed += context =>
        {
            currentScreenPosition = context.ReadValue<Vector2>();
        };
        // axis
        axis.performed += context =>
        {
            rotation = context.ReadValue<Vector2>();
        };
        // press until released: activates dragging
        press.performed += _ =>
        {
            if (IsActive())
            {
                isDragged = true;
            }
        };
        press.canceled += _ =>
        {
            isDragged = false;
            isRotated = false;
        };
        // tap: activates an object-specific menu, deactivates when tapped anywhere else
        tap.performed += _ =>   //  refact with ternary?
        {
            if (IsActive())
            {
                openMenu = true;
            }
            else
            {
                openMenu = false;
            }
        };
        tap.canceled += _ =>
        {
            openMenu = false;
        };
        // 2nd finger press: activates rotating
        doublePress.performed += _ =>
        {
            if (IsActive())
            {
                isRotated = true;
                isDragged = false;
            }
        };
        doublePress.canceled += _ =>
        {
            isRotated = false;
        };
    }
    public bool IsActive()
    {
        Ray ray = Camera.main.ScreenPointToRay(currentScreenPosition);
        // raycast for checking if the touch hits an object in the view
        Physics.Raycast(ray, out RaycastHit hit);
        // compares the transform of the found object to the script's transform 
        // (= if they match, the object has this script and can be set active)
        return hit.transform == transform;

    }
}
