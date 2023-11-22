using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// For testing and ui feedback: changes the object's color according to performed action
public class ObjectColor : MonoBehaviour
{
    // ObjectActions component reference of a certain object
    private ObjectActions objActions;
    // Store all materials of the object
    private List<Material> materials;
    // Store the original colors
    private Dictionary<int, Color> originalColorsDict = new();
    // a nullable color indicator variable
    private Color? indicator;

    private void Start()
    {
        objActions = GetComponent<ObjectActions>();
        // Get all materials attached to the object
        materials = GetComponent<MeshRenderer>().materials.ToList();
        // Store the original colors
        materials.ForEach(m => originalColorsDict[materials.IndexOf(m)] = m.color);
    }
    private void Update()
    {
        indicator = objActions.isDragged ? Color.blue : objActions.isRotated ? Color.green :
            objActions.openMenu ? Color.yellow : null;

        if (indicator != null)
        {
            // Change the action indicator color
            materials.ForEach(m => m.color = (Color)indicator);
        }
        else
        {
            // Restore the original colors
            originalColorsDict.Keys.ToList().ForEach(i => materials[i].color = originalColorsDict[i]);
        }
    }
}
