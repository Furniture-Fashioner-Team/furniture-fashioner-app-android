using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

class FurnitureLoad
{
    private static String pathT = "Assets/Prefabs/Thumbnails/";
    private static String pathF = "Assets/Prefabs/MockFurniture/";
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
 
    public static List<Furniture> LoadFurniture()
    {
        foreach (String name in names)
        {
            try
            {
                Texture2D tex = new Texture2D(0, 0);
                tex.LoadImage(File.ReadAllBytes(pathT + name + ".png"));
                GameObject obj = AssetDatabase.LoadAssetAtPath<GameObject>(pathF + name + ".fbx");
                furniture.Add(new Furniture(name, GetSprite(tex), obj));
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
        return furniture;
    }
}
