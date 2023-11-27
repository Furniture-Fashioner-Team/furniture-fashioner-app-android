using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
