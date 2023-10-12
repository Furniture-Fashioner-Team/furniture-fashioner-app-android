using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectResizer : MonoBehaviour
{
    public Slider sizeSlider;
    public TMPro.TMP_Text scaleText;
    public float minRelativeScale = 0.1f;
    public float maxRelativeScale = 2f;

    private Transform objectToResize;

    private Vector3 initialLocalScale;
    
    private void Start()
    {
        objectToResize = transform;
        initialLocalScale = objectToResize.localScale;
        sizeSlider.onValueChanged.AddListener(ResizeObject);
        UpdateScaleText(initialLocalScale);
    }

    private void ResizeObject(float newSize)
    {
        float relativeScale = Mathf.Lerp(minRelativeScale, maxRelativeScale, newSize);
        Vector3 newLocalScale = initialLocalScale * relativeScale;

        objectToResize.localScale = newLocalScale;

        UpdateScaleText(newLocalScale);
    }

    private void UpdateScaleText(Vector3 currentLocalScale)
    {
        float scale = currentLocalScale.x / initialLocalScale.x;
        
        scaleText.text = $"Scale: {scale:F2}";
    }
}