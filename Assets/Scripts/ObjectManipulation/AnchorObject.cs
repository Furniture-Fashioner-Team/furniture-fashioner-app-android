using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

/* Keeps the object locked into its place when not moving, to restore its 
location in case of drastic camera movements or losing focus, etc. If anchors 
cause performance issues, this component can be removed from ARCamera Prefab.*/ 

public class AnchorObject : MonoBehaviour
{
    private ObjectActions objectActions;
    private ARAnchor anchor;

    void Start() 
    {
        objectActions = GetComponent<ObjectActions>();
    }

    void Update()
    {
        // object is not moved and does not have an anchor component -> create anchor
        if (!objectActions.isDragged && !gameObject.TryGetComponent<ARAnchor>(out anchor))
        {
            gameObject.AddComponent<ARAnchor>();
            Debug.Log("anchor added");
        }

        // object is moved and has an anchor component -> remove anchor
        if (objectActions.isDragged && gameObject.TryGetComponent<ARAnchor>(out anchor)) 
        {
            Destroy(GetComponent<ARAnchor>());
            Debug.Log("anchor removed");
        }
    }
}
