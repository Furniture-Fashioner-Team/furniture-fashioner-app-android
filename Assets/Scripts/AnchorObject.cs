using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AnchorObject : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager;
    [System.Obsolete]
    private ARSessionOrigin sessionOrigin;
    private List<ARRaycastHit> hitResults = new List<ARRaycastHit>();
    private GameObject anchorObject;
    private bool anchorCreated = false;

    [System.Obsolete]
    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
        planeManager = FindObjectOfType<ARPlaneManager>();
        sessionOrigin = FindObjectOfType<ARSessionOrigin>();
    }

    [System.Obsolete]
    void Update()
    {
        // Check if the object is not being dragged or rotated
        if (!GetComponent<ObjectActions>().isDragged && !GetComponent<ObjectActions>().isRotated)
        {
            // Check if the anchor has not been created and a plane has been detected
            if (!anchorCreated && raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hitResults, TrackableType.PlaneWithinPolygon))
            {
                // Get the first hit
                ARRaycastHit hit = hitResults[0];

                // Get the ARPlane object
                ARPlane arPlane = planeManager.GetPlane(hit.trackableId);

                // Check if the ARPlane object is not null
                if (arPlane != null)
                {
                    // Check if the plane detection mode is not set to None
                    if (planeManager.currentDetectionMode != PlaneDetectionMode.None)
                    {
                        // Create a new game object to represent the anchor
                        anchorObject = new GameObject("Anchor");

                        // Set the position and rotation of the anchor relative to the ARSessionOrigin
                        anchorObject.transform.SetParent(sessionOrigin.trackablesParent);
                        anchorObject.transform.localPosition = hit.pose.position;
                        anchorObject.transform.localRotation = hit.pose.rotation;

                        // Parent the object to the anchor
                        gameObject.transform.SetParent(anchorObject.transform);

                        // Add an ARAnchor component to the anchor object
                        anchorObject.AddComponent<ARAnchor>();

                        // Set the boolean variable to true
                        anchorCreated = true;
                    }
                }
            }
        } 
    }
}