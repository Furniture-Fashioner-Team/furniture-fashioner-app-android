using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

// creates a floor plane from the first surface detected by AR Plane Manager

public class CreatePlane : MonoBehaviour
{
    public GameObject planePrefab; // prefab for the plane (remember to assign in the inspector)
    public GameObject plane; // instantiated plane
    private ARPlaneManager planeManager;

    void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
        planeManager.planesChanged += PlaneChanged; // subscribe to Plane Manager's planesChanged event handler, which keeps track of detected surfaces (AR planes)
    }

    // when at least one surface is detected, the floor plane is instantiated
    private void PlaneChanged(ARPlanesChangedEventArgs args)
    {
        if (args.added != null && plane == null)
        {
            ARPlane arPlane = args.added[0]; // first detected surface
            plane = Instantiate(planePrefab, arPlane.transform.position, arPlane.transform.rotation);
        }
    }
}
