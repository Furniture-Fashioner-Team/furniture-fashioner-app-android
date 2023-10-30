using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class PlaceMarker : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    public GameObject marker;
    private List<ARRaycastHit> hitResults = new List<ARRaycastHit>();
    public TMPro.TMP_Text markerLog; // for logging marker's position
    
    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
        marker.SetActive(false); // marker hidden at first
    }

    void Update()
    {
        var ray = new Vector2(Screen.width / 2, Screen.height / 2); // ray at center of screen
        
        // if raycast finds a detected plane, marker is aligned accordingly
        if (raycastManager.Raycast(ray, hitResults, TrackableType.PlaneWithinPolygon)) 
        {
            Pose hitPose = hitResults[0].pose;
            transform.position = hitPose.position;
            transform.rotation = hitPose.rotation;
            if (markerLog != null) 
            {
                markerLog.text = $"Marker: {transform.position}";
            }
            if (!marker.activeInHierarchy) 
            {
                marker.SetActive(true);
            }
        } 
        else 
        {
            marker.SetActive(false); // marker hidden if planes not detected
        }
    }
}
