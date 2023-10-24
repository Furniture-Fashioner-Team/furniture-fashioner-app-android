using System.Collections.Generic;
using UnityEngine;

class Data
{
    public static List<Furniture> furniture;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        furniture = LoadFurniture.Load();
        // furniture.ForEach(f => Debug.Log(f.ToString()));
    } 
}

/*
    In this script, the Initialize method of the Data class is such that it is called
    before loading the first scene. The previous matter is defined with an expression monster
    that can possibly be equated with Java annotations:
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)].
    
    The idea is to provide the application with a list of Furniture objects that can be referenced
    in other scripts like this: 'Data.furniture'. The 3D models contained in the obj variable
    of these Furniture objects can then be added to the application using the Unity Instantiate
    function, and the Sprites contained in the spr variable of the Furniture objects can be added
    to a potential visual object menu.
*/
