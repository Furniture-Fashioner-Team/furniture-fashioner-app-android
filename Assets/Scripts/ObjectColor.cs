using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// for testing: changes the object's color according to performed action

public class ObjectColor : MonoBehaviour
{
    private Color objColor = Color.white;
    private ObjectActions objActions;

    void Start()
    {
        objActions = GetComponent<ObjectActions>();
    }

    void Update()
    {
        // set color according to action
        if (objActions.isDragged == true) {
            objColor = Color.blue;
        } else if (objActions.isRotated == true) {
            objColor = Color.green;
        } else if (objActions.openMenu == true) {
            objColor = Color.yellow;
        } else {
            objColor = Color.white;
        }
        // render the color on screen
        GetComponent<MeshRenderer>().material.color = objColor;
    }
}
