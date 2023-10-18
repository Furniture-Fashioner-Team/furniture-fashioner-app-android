using UnityEngine;
using UnityEngine.UI;

public class ResizeObject : MonoBehaviour
{
    public Slider sizeSlider;
    private Transform tr;
    private Vector3 origSize;
    private float[] minMax = { 0.1f, 2.0f };

    private void Awake()
    {
        tr = transform;
        origSize = tr.localScale;
    }

    private void Start()
    {
        sizeSlider.value = 0.5f;
        sizeSlider.onValueChanged.AddListener(Resize);
    }

    public void Resize(float modifier)
    {
        tr.localScale = Mathf.Lerp(minMax[0], minMax[1], modifier) * origSize;
    }
}
