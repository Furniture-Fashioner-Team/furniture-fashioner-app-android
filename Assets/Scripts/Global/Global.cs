using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
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
    the application! On the other hand, the 'AddClickListener' function of this script is used
    to add event listeners to both the Menu sprite images and the ARCamera user interface icons.
*/
class Global
{
    public static string[] sceneNames = { "ARCamera", "Menu" };
    public static int[] dim = { Screen.width, Screen.height };

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        LoadData.Load(GlobalMenu.furniture);
        GlobalMenu.furnitureCount = GlobalMenu.furniture.Count;
        GlobalMenu.scrollViewSize = new Vector2(dim[0] * 0.5f, dim[1] * 0.45f);
        GlobalMenu.scrollBarSize = new Vector2(dim[0] * 0.035f, dim[1] * 0.45f);
        GlobalMenu.toCameraSize = new Vector2(dim[0] * 0.208f, dim[1] * 0.032f);
        GlobalMenu.toCameraPlace = new Vector2(0, dim[1] * -0.23f);
        GlobalMenu.toCameraFontSize = (int)Math.Round(dim[0] * 0.029f);
        GlobalMenu.imgScaleFact = GlobalMenu.scrollViewSize.y * 0.22f;
        GlobalMenu.spriteImageSize = new Vector2(1.920f * GlobalMenu.imgScaleFact, 1.080f * GlobalMenu.imgScaleFact);
        GlobalARC.iconSize = new Vector2(dim[0] * 0.1042f, dim[1] * 0.0485f);
        GlobalARC.menuIconPlace = new Vector2(dim[0] * -0.399f, dim[1] * 0.461f);
        GlobalARC.trashCanPlace = new Vector2(dim[0] * 0.399f, dim[1] * -0.461f);
        GlobalARC.duplicatePlace = new Vector2(dim[0] * -0.399f, dim[1] * -0.461f);
        GlobalARC.newObjPlace = new Vector3(0, 0, 3);
    }
    public static Tuple<EventTrigger.Entry, EventTrigger> AddClickListener(GameObject obj)
    {
        EventTrigger eT = obj.AddComponent<EventTrigger>();
        EventTrigger.Entry e = new EventTrigger.Entry();
        e.eventID = EventTriggerType.PointerClick;
        return new Tuple<EventTrigger.Entry, EventTrigger>(e, eT);
    }
}