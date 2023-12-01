using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
/* 
    This script controls the visibility of the UI components. 
*/
public class UIController : MonoBehaviour
{
    public Image menuIcon;
    public Image trashCan;
    public Image duplicate;
    public GameObject loadingText;

    // Checks marker visibility to control when to show/hide the menu icon and loading text
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
    
    // Goes through all the ObjectActions components and returns the one with openMenu set as true, or null
    public static ObjectActions GetActiveObjectActions()
    {
        return FindObjectsOfType<ObjectActions>().FirstOrDefault(comp => comp.openMenu);
    }

    private void Start()
    {
        menuIcon.gameObject.SetActive(false);
        trashCan.gameObject.SetActive(false);
        duplicate.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Menu icon and loading text
        if (GetMarkerVisibility() == true)
        {
            menuIcon.gameObject.SetActive(true);
            loadingText.gameObject.SetActive(false);
        }
        else
        {
            menuIcon.gameObject.SetActive(false);
            loadingText.gameObject.SetActive(true);
        }

        // Delete and duplicate icons
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
