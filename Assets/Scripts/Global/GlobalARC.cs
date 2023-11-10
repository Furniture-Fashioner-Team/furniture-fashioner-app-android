using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class GlobalARC
{
    public static Vector2 arrowLeftSize;
    public static Vector2 arrowLeftPlace;
    public static Vector3 newObjPlace;
    public static Dictionary<int, (GameObject obj, GameObject inst)> aRObjDict = new();
    public static Slider slider;
}

/*
    This script defines global-level variables used in the 'ARCamera' related scripts.
*/
