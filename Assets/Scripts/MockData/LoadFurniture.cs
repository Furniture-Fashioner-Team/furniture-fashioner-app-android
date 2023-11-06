using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

class LoadFurniture
{
    public static string sAP = Application.streamingAssetsPath;
    public static AssetBundle aBT;
    public static AssetBundle aBF;
    private static String[] names = SetNames();

    private static String[] SetNames()
    {
        return new String[] { "ikea-hyllykko", "jakkara", "lavitta",
            "palli", "poyta", "soffa" };
    }
    private static Sprite GetSprite(Texture2D tex)
    {
        return Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.one / 2f);
    }
    public static void Load(List<Furniture> list)
    {
        try
        {
            aBT = AssetBundle.LoadFromFile(Path.Combine(sAP, "thumbs"));
            aBF = AssetBundle.LoadFromFile(Path.Combine(sAP, "mockfurniture"));

            foreach (String name in names)
            {
                Texture2D tex = aBT.LoadAsset<Texture2D>(name);
                GameObject obj = aBF.LoadAsset<GameObject>(name);
                list.Add(new Furniture(name, GetSprite(tex), obj));
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }
}
