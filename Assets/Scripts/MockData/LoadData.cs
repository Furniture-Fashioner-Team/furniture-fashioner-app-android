using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

class LoadData
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

/*
    In this script, AssetBundles containing images and 3D models of furniture are loaded from
    the StreamingAssets folder. These images are used to create sprites. The use of AssetBundles
    as a source is necessary if you want to add data to the application at runtime. It appears
    that using AssetBundles as a source is also possible asynchronously, so in this approach,
    we are coming closer to the situation in the final version of the application where data is
    loaded into the application, for example, using a REST API.
*/
