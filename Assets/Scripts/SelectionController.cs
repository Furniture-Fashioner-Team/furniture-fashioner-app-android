using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class SelectionController : MonoBehaviour
{
    // The parent object containing the furniture, aka children to toggle
    public Transform parentObject;
    public Transform mainCamera; // Reference to the main camera in the scene
    public float distanceFromCamera = 5f; // Distance from the camera to position objects
    public TMPro.TMP_Dropdown dropdown; // Reference to a dropdown UI element, used for object selection

    // Dictionary to track if each object has been positioned
    private Dictionary<string, bool> objectPositioned = new Dictionary<string, bool>();

    private void Start()
    {
        if (dropdown == null)
        {
            // Display an error message if the dropdown is not assigned
            Debug.LogError("Dropdown is not assigned!");
            enabled = false;
            return;
        }

        // Add a listener to respond to changes in the dropdown value
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    private void OnDropdownValueChanged(int selection)
    {
        // Get the name of the selected object from the dropdown
        string selectedObjectName = dropdown.options[selection].text;

        // Check if the object has been positioned before, we only want to position the object in front of the camera on first selection
        if (!objectPositioned.ContainsKey(selectedObjectName) || !objectPositioned[selectedObjectName])
        {
            // Position the object in front of the camera
            PositionObjectInFrontOfCamera(selectedObjectName);
            objectPositioned[selectedObjectName] = true;
        }

        if (parentObject != null)
        {
            // Iterate through the children of the parent object
            foreach (Transform child in parentObject)
            {
                if (child != null)
                {
                    if (selectedObjectName == child.gameObject.name)
                    {
                        // Enable MeshRenderer and Collider components for the selected object
                        ToggleObjectVisibility(child, true);
                    }
                    else
                    {
                        // Disable MeshRenderer and Collider components for other objects
                        ToggleObjectVisibility(child, false);
                    }
                }
            }
        }
        else
        {
            // Display an error if the parent object is not assigned
            Debug.LogError("Parent object is not assigned!");
        }
    }

    private void PositionObjectInFrontOfCamera(string objectName)
    {
        if (parentObject != null && mainCamera != null)
        {
            // Calculate the position in front of the camera and move the selected object there
            Vector3 cameraPosition = mainCamera.transform.position;
            Vector3 cameraForward = mainCamera.transform.forward;
            Quaternion cameraRotation = mainCamera.transform.rotation;
            Vector3 targetPosition = cameraPosition + cameraRotation * Vector3.forward * distanceFromCamera;

            foreach (Transform child in parentObject)
            {
                if (child != null && objectName == child.gameObject.name)
                {
                    child.position = targetPosition;
                }
            }
        }
        else
        {
            // Display an error if the parent object or main camera is not assigned
            Debug.LogError("Parent object or mainCamera is null in PositionObjectInFrontOfCamera!");
        }
    }

    private void ToggleObjectVisibility(Transform obj, bool enable)
    {
        if (obj != null)
        {
            // Enable or disable MeshRenderer and Collider components for the object
            MeshRenderer renderer = obj.GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                renderer.enabled = enable;
            }

            Collider collider = obj.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = enable;
            }
        }
    }

      public void ResetSelection()
    {
        // Reset the dictionary tracking if objects have been positioned
        objectPositioned.Clear();

        // Clear the dropdown selection (set it to the first item)
        if (dropdown != null)
        {
            dropdown.value = 0; // Set it to the default value (first item)
        }

        // Hide all objects by disabling their MeshRenderer and Collider components
        if (parentObject != null)
        {
            foreach (Transform child in parentObject)
            {
                ToggleObjectVisibility(child, false);
            }
        }
    }
}