using System.Collections.Generic;
using UnityEngine;

class Data
{
    public static List<Furniture> furniture;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        furniture = FurnitureLoad.LoadFurniture();
        furniture.ForEach(f => Debug.Log(f.ToString()));
    } 
}
