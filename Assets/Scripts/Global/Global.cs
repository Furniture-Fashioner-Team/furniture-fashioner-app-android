using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

class Global
{
    public static string[] sceneNames = { "Menu", "ARCamera" };
    public static int[] dim = { Screen.width, Screen.height };

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        LoadData.Load(GlobalMenu.furniture);
        GlobalMenu.furnitureCount = GlobalMenu.furniture.Count;
        GlobalMenu.scrollViewSize = new Vector2(dim[0] * 0.5f, dim[1] * 0.45f);
        GlobalMenu.buttonSize = new Vector2(dim[0] * 0.208f, dim[1] * 0.032f);
        GlobalMenu.buttonFontSize = (int)Math.Round(dim[0] * 0.029f);
        GlobalMenu.imgScaleFact = GlobalMenu.scrollViewSize.y * 0.22f;
        GlobalMenu.spriteImageSize = new Vector2(1.920f * GlobalMenu.imgScaleFact, 1.080f * GlobalMenu.imgScaleFact);
        GlobalARC.arrowLeftSize = new Vector2(dim[0] * 0.0694f, dim[1] * 0.0324f);
        GlobalARC.arrowLeftPlace = new Vector2(dim[0] * -0.45f, dim[1] * 0.48f);
        GlobalARC.newObjPlace = new Vector3(0, 0, 5);
    }
    public static Tuple<EventTrigger.Entry, EventTrigger> AddClickListener(GameObject obj)
    {
        EventTrigger eT = obj.AddComponent<EventTrigger>();
        EventTrigger.Entry e = new EventTrigger.Entry();
        e.eventID = EventTriggerType.PointerClick;
        return new Tuple<EventTrigger.Entry, EventTrigger>(e, eT);
    }
}

/*
    In this script, the Initialize method of the Global class is such that it is called
    before loading the first scene. The previous matter is defined with an expression monster
    that can possibly be equated with Java annotations:
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)].
    
    The idea is to provide the application with a list of Furniture objects that can be referenced
    in other scripts like this: 'GlobalMenu.furniture'. The 3D models contained in the obj variable
    of these Furniture objects can then be added to the application using the Unity Instantiate
    function, and the Sprites contained in the spr variable of the Furniture objects can be added
    to a visual object menu.

    This script also sets values of the other global-level variables that can be used throughout
    the application!
*/
