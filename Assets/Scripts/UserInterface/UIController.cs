using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

// controls the ui components visibility
public class UIController : MonoBehaviour
{
    public Image trashCan;
    public Image duplicate;
    
    void Start()
    {
        trashCan.gameObject.SetActive(false);
        duplicate.gameObject.SetActive(false);
    }
    public static ObjectActions GetActiveObjectActions()
    {
        // goes through all the ObjectActions components and returns the one with openMenu set as true or null
        return FindObjectsOfType<ObjectActions>().FirstOrDefault(comp => comp.openMenu);
    }
    void Update()
    {
        // shows/hides the size slider according to openMenu value in the objectActions script
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
