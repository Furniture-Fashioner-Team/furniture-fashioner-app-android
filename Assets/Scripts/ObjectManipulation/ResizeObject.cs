using UnityEngine;
using UnityEngine.UI;

public class ResizeObject : MonoBehaviour
{
    public Slider slider;
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
        slider.value = 0.5f;
        slider.onValueChanged.AddListener(Resize);
    }
    public void Resize(float modifier)
    {
        tr.localScale = Mathf.Lerp(minMax[0], minMax[1], modifier) * origSize;
    }
}
 // Ei siis enää tämmöistä objektiin liitettävää, vaan joku staattisempi toiminto, joka
 // tarkkailee, että mikä esine valittuna, ja vaikuttaa sitten siihen, maybe...