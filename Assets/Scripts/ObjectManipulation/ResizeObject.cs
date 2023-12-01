using UnityEngine;
using UnityEngine.UI;

/*
    For adjusting a furniture object's scale.
*/
public class ResizeObject : MonoBehaviour
{
    private Transform tr;
    private Vector3 origSize;

    private void Awake()
    {
        tr = transform;
        origSize = tr.localScale;
    }
    public void Resize(float modifier)
    {
        tr.localScale = modifier * origSize;
    }
}
