using UnityEngine;
using UnityEngine.SceneManagement;

class ARCamera : MonoBehaviour
{
    private GameObject newObj;
    private void Awake()
    {
        if (Global.furnitureKey != null)
        {
            newObj = Global.furnitureDict[(int)Global.furnitureKey];
            newObj = Instantiate(newObj, new Vector3(0, 0, 5), newObj.transform.localRotation);
            // Destroy(newObj);
        }
    }
}
