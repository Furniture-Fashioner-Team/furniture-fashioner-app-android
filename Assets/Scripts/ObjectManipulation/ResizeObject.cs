using UnityEngine;
using UnityEngine.UI;

public class ResizeObject : MonoBehaviour
{
    public Slider slider;
    private Transform tr;
    private Vector3 origSize;
    private float[] minMax = { 0.1f, 2.0f };
    private ObjectActions objActions;

    private void Awake()
    {
        tr = transform;
        origSize = tr.localScale;
        objActions = GetComponent<ObjectActions>();
    }
    private void Start()
    {
        slider.value = 0.5f;
        slider.onValueChanged.AddListener(Resize);
    }
    public void Resize(float modifier)
    {
        if (objActions.openMenu == true) 
        {
            tr.localScale = Mathf.Lerp(minMax[0], minMax[1], modifier) * origSize;
        }
    }
}
