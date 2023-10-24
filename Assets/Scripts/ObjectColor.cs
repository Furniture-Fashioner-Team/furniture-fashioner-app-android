using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For testing: changes the object's color according to performed action

public class ObjectColor : MonoBehaviour
{
    private Color[] originalColors; // Store the original colors
    private ObjectActions objActions;
    private Material[] materials; // Store all materials of the object

    void Start()
    {
        objActions = GetComponent<ObjectActions>();

        // Get all materials attached to the object
        materials = GetComponent<MeshRenderer>().materials;

        // Store the original colors
        originalColors = new Color[materials.Length];
        for (int i = 0; i < materials.Length; i++)
        {
            originalColors[i] = materials[i].color;
        }
    }

    void Update()
    {
        for (int i = 0; i < materials.Length; i++)
        {
            // Set the color according to action
            if (objActions.isDragged)
            {
                materials[i].color = Color.blue;
            }
            else if (objActions.isRotated)
            {
                materials[i].color = Color.green;
            }
            else if (objActions.openMenu)
            {
                materials[i].color = Color.yellow;
            }
            else
            {
                // Restore the original color
                materials[i].color = originalColors[i];
            }
        }
    }
}