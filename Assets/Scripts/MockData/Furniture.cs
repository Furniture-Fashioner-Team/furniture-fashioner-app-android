using System;
using UnityEngine;

class Furniture
{
    public String name;
    public Sprite spr;
    public GameObject obj;

    public Furniture(String n, Sprite s, GameObject o)
    {
        this.name = n;
        this.spr = s;
        this.obj = o;
    }

    public override String ToString()
    {
        return String.Format("Name: {0}\nSprite: {1}\nGameObject: {2}\n\n", name, spr, obj);
    }
}
