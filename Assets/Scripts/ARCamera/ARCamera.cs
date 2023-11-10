using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class ARCamera : MonoBehaviour
{
    public GameObject arrowLeft;
    public Slider slider;

    private void Awake()
    {
        ARCameraFunc.ArrowLeftSettings(arrowLeft);
        GlobalARC.slider = slider;
    }
    private void Start()
    {
        ARCameraFunc.OldARObjects();
        ARCameraFunc.NewObject();
        // Destroy(newObj);
    }
}
