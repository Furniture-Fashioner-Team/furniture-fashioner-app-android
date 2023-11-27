using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/* controls the ui components' visibility */

public class UIController : MonoBehaviour
{
    public Image menuIcon;
    public Image trashCan;
    public Image duplicate;
    
    private void Start()
    {
        menuIcon.gameObject.SetActive(false);
        trashCan.gameObject.SetActive(false);
        duplicate.gameObject.SetActive(false);
    }

    public static bool GetMarkerVisibility()
    {
        if (GameObject.Find("Marker") != null)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
    
    public static ObjectActions GetActiveObjectActions()
    {
        // goes through all the ObjectActions components and returns the one with openMenu set as true, or null
        return FindObjectsOfType<ObjectActions>().FirstOrDefault(comp => comp.openMenu);
    }

    private void Update()
    {
        // menu icon
        if (GetMarkerVisibility() == true)
        {
            menuIcon.gameObject.SetActive(true);
        }
        else
        {
            menuIcon.gameObject.SetActive(false);
        }

        // delete and duplicate icons
        if (GetActiveObjectActions() != null) 
        {
            trashCan.gameObject.SetActive(true);
            duplicate.gameObject.SetActive(true);
        } 
        else 
        {
            trashCan.gameObject.SetActive(false);
            duplicate.gameObject.SetActive(false);
        }
    }
}
