using UnityEngine;
using UnityEngine.UI;

class ARCamera : MonoBehaviour
{
    public GameObject arrowLeft;
    private GameObject newObj;
    public Slider slider;

    private void Awake()
    {
        ARCameraFunc.ArrowLeftSettings(arrowLeft);
    }
    private void Start()
    {
        NewObject();
        AddResizeObject();
        // Destroy(newObj);
    }
    private void NewObject()
    {
        if (Global.furnitureKey != null)
        {
            newObj = Global.furnitureDict[(int)Global.furnitureKey];
            newObj = Instantiate(newObj, new Vector3(0, 0, 5), newObj.transform.localRotation);
        }
    }
    private void AddResizeObject()
    {
        if (newObj != null)
        {
            ResizeObject rO = newObj.AddComponent<ResizeObject>();
            rO.slider = slider;
        }
    }
}
