using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
    This script defines global-level variables used in the 'Menu' related scripts.
*/
class GlobalMenu
{
    public static List<Furniture> furniture = new();
    public static int furnitureCount;
    public static Vector2 scrollViewSize;
    public static Vector2 scrollBarSize;
    public static Vector2 toCameraSize;
    public static Vector2 toCameraPlace;
    public static int toCameraFontSize;
    public static float imgScaleFact;
    public static Vector2 spriteImageSize;
    public static Dictionary<int, GameObject> furnitureDict = new();
    public static Image selectedImage;
    public static int? furnitureKey;
}