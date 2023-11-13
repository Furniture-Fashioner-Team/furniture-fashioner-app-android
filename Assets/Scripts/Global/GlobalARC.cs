using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class GlobalARC
{
    public static Vector2 iconSize;
    public static Vector2 arrowLeftPlace;
    public static Vector2 trashCanPlace;
    public static Vector3 newObjPlace;
    public static Dictionary<int, (GameObject obj, GameObject inst)> aRObjDict = new();
    public static int? aRObjKey;
}

/*
    This script defines global-level variables used in the 'ARCamera' related scripts.
*/
