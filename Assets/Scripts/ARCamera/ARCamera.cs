using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class ARCamera : MonoBehaviour
{
    private GameObject newObj;
    public Slider slider;

    private void Awake()
    {
        NewObject();
    }
    private void Start()
    {
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
            ResizeObject resObj = newObj.AddComponent<ResizeObject>();
            resObj.slider = slider;
        }
    }
}