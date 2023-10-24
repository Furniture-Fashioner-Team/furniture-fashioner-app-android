using System.Collections.Generic;
using UnityEngine;

public class Data
{
    public static List<Furniture> furniture;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        furniture = LoadFurniture.Load();
        // furniture.ForEach(f => Debug.Log(f.ToString()));
    } 
}

