using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class SelectionController : MonoBehaviour
{
    public Transform[] objectsToToggle; // An array of objects to enable/disable
    public Transform mainCamera;
    public float distanceFromCamera = 5f;
    public TMPro.TMP_Dropdown dropdown;

    private bool hasPositioned = false;

    // Dictionary to track if each object has been positioned
    private Dictionary<string, bool> objectPositioned = new Dictionary<string, bool>();

    private void Start()
    {
        if (dropdown == null)
        {
            Debug.LogError("Dropdown is not assigned!");
            enabled = false;
            return;
        }

        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    private void OnDropdownValueChanged(int selection)
    {
        string selectedObjectName = dropdown.options[selection].text;

        // Check if the object has been positioned before
        if (!objectPositioned.ContainsKey(selectedObjectName) || !objectPositioned[selectedObjectName])
        {
            // Position the object in front of the camera
            PositionObjectInFrontOfCamera(selectedObjectName);
            objectPositioned[selectedObjectName] = true;
        }

        foreach (Transform objToToggle in objectsToToggle)
        {
            if (objToToggle != null)
            {
                if (selectedObjectName == objToToggle.gameObject.name)
                {
                    // Enable MeshRenderer and Collider components
                    ToggleObjectVisibility(objToToggle, true);
                }
                else
                {
                    // Disable MeshRenderer and Collider components
                    ToggleObjectVisibility(objToToggle, false);
                }
            }
        }
    }

    private void PositionObjectInFrontOfCamera(string objectName)
    {
        if (objectsToToggle.Length > 0 && mainCamera != null)
        {
            Vector3 cameraPosition = mainCamera.transform.position;
            Vector3 cameraForward = mainCamera.transform.forward;
            Quaternion cameraRotation = mainCamera.transform.rotation;
            Vector3 targetPosition = cameraPosition + cameraRotation * Vector3.forward * distanceFromCamera;

            foreach (Transform objToToggle in objectsToToggle)
            {
                if (objToToggle != null && objectName == objToToggle.gameObject.name)
                {
                    objToToggle.position = targetPosition;
                }
            }
        }
        else
        {
            Debug.LogError("Objects to toggle or mainCamera is null in PositionObjectInFrontOfCamera!");
        }
    }

    private void ToggleObjectVisibility(Transform obj, bool enable)
    {
        if (obj != null)
        {
            // Enable or disable MeshRenderer and Collider components
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

    // Hide all objects
    foreach (Transform objToToggle in objectsToToggle)
    {
        ToggleObjectVisibility(objToToggle, false);
    }

    hasPositioned = false;
}
}