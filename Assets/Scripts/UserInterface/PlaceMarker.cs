using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

/* Controls the place marker that indicates detected surfaces. Its 
position is used for determining where a new object is instantiated. */

public class PlaceMarker : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    public GameObject marker;
    private List<ARRaycastHit> hitResults = new List<ARRaycastHit>();
    
    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
        marker.SetActive(false);
    }

    void Update()
    {
        var ray = new Vector2(Screen.width / 2, Screen.height / 2); // center of screen
        
        // if raycast finds a detected plane, marker is aligned accordingly
        if (raycastManager.Raycast(ray, hitResults, TrackableType.PlaneWithinPolygon)) 
        {
            Pose hitPose = hitResults[0].pose;
            transform.position = hitPose.position;
            transform.rotation = hitPose.rotation;
            if (!marker.activeInHierarchy) 
            {
                marker.SetActive(true);
            } 

            // update object instantiation coordinates when marker is active
            GlobalARC.newObjPlace = transform.position;
        } 
        else 
        {
            marker.SetActive(false);
        }
    }
}
