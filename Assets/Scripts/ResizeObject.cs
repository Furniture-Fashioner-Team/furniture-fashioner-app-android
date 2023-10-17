using UnityEngine;
using UnityEngine.UI;

public class ObjectResizer : MonoBehaviour
{
    public Slider sizeSlider;
    private Transform tr;
    private Vector3 origSize;
    private float[] minMax = { 0.1f, 2.0f };
    public TMPro.TMP_Text scaleText;

    private void Awake()
    {
        tr = transform;
        origSize = tr.localScale;
    }

    private void Start()
    {
        sizeSlider.value = 0.5f;
        sizeSlider.onValueChanged.AddListener(ResizeObject);
    }

    public void ResizeObject(float modifier)
    {
        tr.localScale = Mathf.Lerp(minMax[0], minMax[1], modifier) * origSize;
        scaleText.text = $"Scale: {tr.localScale.x:F2}";
    }
}