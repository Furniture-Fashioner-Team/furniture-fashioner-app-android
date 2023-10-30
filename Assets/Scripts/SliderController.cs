using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// controls the slider's visibility

public class SliderController : MonoBehaviour
{
    public Slider slider; // reference to the slider

    public static ObjectActions GetActiveObject()
    {
        // goes through all resizeable objects and returns the one with openMenu set as true
        ObjectActions[] objectActionsArray = FindObjectsOfType<ObjectActions>();
        foreach (ObjectActions objectActions in objectActionsArray)
        {
            if (objectActions.openMenu == true)
            {
                return objectActions;
            }
        }
        return null; // if no object found
    }
    
    void Start()
    {
        slider.gameObject.SetActive(false); // slider hidden at first
    }

    void Update()
    {
        // shows/hides the size slider according to openMenu value in the objectActions script
        if (GetActiveObject() != null) 
        {
            slider.gameObject.SetActive(true);
        } 
        else 
        {
            slider.gameObject.SetActive(false);
        }
    }
}

