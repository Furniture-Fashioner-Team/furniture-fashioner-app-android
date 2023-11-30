using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
    This script defines global-level variables used in the 'ARCamera' related scripts.
*/
class GlobalARC
{
    public static Vector2 iconSize;
    public static Vector2 menuIconPlace;
    public static Vector2 trashCanPlace;
    public static Vector2 duplicatePlace;
    public static Vector3 newObjPlace;
    public static Dictionary<int, GameObject> aRObjDict = new();
    public static int? aRObjKey;
}