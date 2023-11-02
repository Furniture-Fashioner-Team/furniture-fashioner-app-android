using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class Global
{
    public static string[] sceneNames = { "Menu", "ARCamera" };
    public static List<Furniture> furniture;
    public static int furnitureCount;
    public static Vector2 scrollViewSize;
    public static Vector2 buttonSize;
    public static int buttonFontSize;
    public static int[] dim = { Screen.width, Screen.height };
    public static float imgScaleFact;
    public static Vector2 spriteImageSize;
    public static Dictionary<int, GameObject> furnitureDict = new();
    public static Image selectedImage;
    public static int? furnitureKey;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        furniture = LoadFurniture.Load();
        furnitureCount = furniture.Count;
        scrollViewSize = new Vector2(dim[0] * 0.5f, dim[1] * 0.45f);
        buttonSize = new Vector2(dim[0] * 0.208f, dim[1] * 0.032f);
        buttonFontSize = (int)Math.Round(dim[0] * 0.029f);
        imgScaleFact = scrollViewSize.y * 0.22f;
        spriteImageSize = new Vector2(1.920f * imgScaleFact, 1.080f * imgScaleFact);
    }
}

/*
    In this script, the Initialize method of the Global class is such that it is called
    before loading the first scene. The previous matter is defined with an expression monster
    that can possibly be equated with Java annotations:
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)].
    
    The idea is to provide the application with a list of Furniture objects that can be referenced
    in other scripts like this: 'Global.furniture'. The 3D models contained in the obj variable
    of these Furniture objects can then be added to the application using the Unity Instantiate
    function, and the Sprites contained in the spr variable of the Furniture objects can be added
    to a visual object menu.

    This script also defines other global-level variables that can be used throughout the application.
    These global-level variables can be defined more when needed!
*/
