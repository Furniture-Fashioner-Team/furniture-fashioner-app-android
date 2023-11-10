using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


// Joonaksen yritys ankkuroinnin pohtimiseen
public class AnchorObject : MonoBehaviour
{
    private ARAnchorManager anchorManager;
    private ObjectActions objectActions;
    private ARAnchor anchor;
    private bool isDragging = false;

    void Start() 
    {
        anchorManager = GetComponent<ARAnchorManager>();
        objectActions = GetComponent<ObjectActions>();
    }

    void Update()
    {
        // Check if the object is being dragged
        if (GetComponent<ObjectActions>().isDragged)
        {
            isDragging = true;
        }
        else
        {
            isDragging = false;
        }

        // Check if the object is not being dragged and does not have an anchor component -> create anchor
        if (!isDragging && !gameObject.TryGetComponent<ARAnchor>(out anchor) && !objectActions.isActive())
        {
            gameObject.AddComponent<ARAnchor>();
            Debug.Log("anchor added");
        }

        // Check if the object is active and has an anchor component -> remove anchor
        if (objectActions.isActive() && gameObject.TryGetComponent<ARAnchor>(out anchor)) 
        {
            Destroy(GetComponent<ARAnchor>());
            Debug.Log("anchor removed");
        }
    }
}