using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public bool openMenu = false;
    public bool isDragged = false;
    public bool isRotated = false;

    // setup tasks
    private void Awake()
    {
        screenPosition = new InputAction(type: InputActionType.Value, binding: "<Touchscreen>/position");
        axis = new InputAction(type: InputActionType.Value, binding: "<Touchscreen>/delta");
        press = new InputAction(type: InputActionType.Button, binding: "<Touchscreen>/press");
        tap = new InputAction(type: InputActionType.Button, binding: "<Touchscreen>/primaryTouch/tap", interactions: "tap");
        doublePress = new InputAction(type: InputActionType.Button, binding: "<Touchscreen>/touch1/press");

        // touch position
        screenPosition.performed += context => currentScreenPosition = context.ReadValue<Vector2>();
        // axis
        axis.performed += context => rotation = context.ReadValue<Vector2>();
        // tap: activates an object-specific menu, deactivates when tapped anywhere else
        tap.performed += _ => openMenu = isActive();
        // press until released: activates dragging
        press.performed += _ =>
        {
            if (isActive())
            {
                // logic for setting main camera's audio source's clip to select.mp3 before playing it
                AudioClip selectAudioClip = Resources.Load<AudioClip>("Sounds/select");
                AudioSource audioSource = Camera.main.GetComponent<AudioSource>();
                audioSource.clip = selectAudioClip;
                audioSource.Play();

                ResetOpenMenuValues();
                isDragged = true;
                isRotated = false;
            }
        };
        press.canceled += _ => isDragged = false;
        // 2nd finger press: activates rotating
        doublePress.performed += _ =>
        {
            if (isActive())
            {
                ResetOpenMenuValues();
                isRotated = true;
                isDragged = false;
            }
        };
        doublePress.canceled += _ => isRotated = false;
    }
    private void Start()
    {
        screenPosition.Enable();
        axis.Enable();
        press.Enable();
        tap.Enable();
        doublePress.Enable();
    }
    public bool isActive()
    {
        Ray ray = Camera.main.ScreenPointToRay(currentScreenPosition);
        // a ray is created
        Physics.Raycast(ray, out RaycastHit hit);
        // a ray is casted
        bool active = hit.transform == transform;
        // does the ray hit the object?
        if (active)
        {
            GlobalARC.aRObjKey = gameObject.GetInstanceID();
        }
        /*
            if the ray hits the object this script is attached to, the GlobalARC.aRObjKey value is
            set so that we know which item in the scene is selected, and the boolean value is
            returned, so that the other scripts know if their parent object is selected
        */
        return active;
    }
    private void ResetOpenMenuValues()
    {
        FindObjectsOfType<ObjectActions>().ToList().ForEach(comp => comp.openMenu = false);
    }
    private void OnDestroy()
    {
        screenPosition.Disable();
        axis.Disable();
        press.Disable();
        tap.Disable();
        doublePress.Disable();
    }
}
