using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CreatePlane : MonoBehaviour
{
    public GameObject planePrefab;
    public GameObject newPlane;
    private ARPlaneManager planeManager;

    void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
        planeManager.planesChanged += PlaneChanged;
    }

    private void PlaneChanged(ARPlanesChangedEventArgs args)
    {
        if (args.added != null && newPlane == null)
        {
            ARPlane arPlane = args.added[0];
            newPlane = Instantiate(planePrefab, arPlane.transform.position, arPlane.transform.rotation);
        }
    }

    void Update()
    {
        
    }
}
