using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class ARCamera : MonoBehaviour
{
    public GameObject arrowLeft;
    public GameObject trashCan;
    public GameObject aRCameraPrefab;
    public Slider slider;

    private void Awake()
    {
        ARCameraFunc.ArrowLeftSettings(arrowLeft);
        ARCameraFunc.TrashCanSettings(trashCan);
    }
    private void Start()
    {
        ARCameraFunc.OldARObjects();
        ARCameraFunc.NewObject(aRCameraPrefab, slider);
        // Destroy(newObj);
    }
}
