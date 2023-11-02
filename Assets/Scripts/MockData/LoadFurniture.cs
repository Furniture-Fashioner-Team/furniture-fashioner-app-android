using System;
using System.Collections.Generic;
using UnityEngine;

class LoadFurniture
{
    public static string appDP = Application.dataPath;
    public static AssetBundle aBT;
    public static AssetBundle aBF;
    private static String[] names = SetNames();
    private static List<Furniture> furniture = new();

    private static String[] SetNames()
    {
        return new String[] { "ikea-hyllykko", "jakkara", "lavitta",
            "palli", "poyta", "soffa" };
    }
    private static Sprite GetSprite(Texture2D tex)
    {
        return Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.one / 2f);
    }
    public static List<Furniture> Load()
    {
        try
        {
            aBT = AssetBundle.LoadFromFile(appDP + "/AssetBundles/thumbs");
            aBF = AssetBundle.LoadFromFile(appDP + "/AssetBundles/mockfurniture");

            foreach (String name in names)
            {
                Texture2D tex = aBT.LoadAsset<Texture2D>(name);
                GameObject obj = aBF.LoadAsset<GameObject>(name);
                furniture.Add(new Furniture(name, GetSprite(tex), obj));
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
        return furniture;
    }
}

/*
    In this script, Furniture objects are created and stored in the furniture class variable.
    When the loading of objects is complete, the Load method returns a list of Furniture objects.
*/
