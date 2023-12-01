using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
    This script defines the variables visible to Unity: menuIcon, trashCan, and duplicate,
    which are UI components. The 'aRCameraPrefab' component's task is to provide a ready-made
    setup for adding new items to the augmented reality camera view. In the component, everything
    else is prepared except for the 3D model of the item, which gets attached to the component
    when a new item is added. Upon entering the camera view, it checks if there are existing
    augmented reality items, and if so, they are made visible by calling the 'ARCameraFunc.OldARObjects'
    function. Conversely, if the user wants to add a new augmented reality item, it is added to the
    camera view by calling the 'ARCameraFunc.NewObject' function.
*/
class ARCamera : MonoBehaviour
{
    public GameObject menuIcon;
    public GameObject trashCan;
    public GameObject duplicate;
    public GameObject aRCameraPrefab;

    private void Awake()
    {
        ARCameraFunc.MenuIconSettings(menuIcon);
        ARCameraFunc.TrashCanSettings(trashCan);
        ARCameraFunc.DuplicateSettings(duplicate);
    }
    private void Start()
    {
        ARCameraFunc.OldARObjects();
        ARCameraFunc.NewObject(aRCameraPrefab);
    }
}
