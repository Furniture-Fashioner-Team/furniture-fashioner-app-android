using System;
using UnityEngine;
/*
    In this script, a Furniture class is defined, with object variables being the name of the object,
    the object's Sprite (created from the object's png image), and the object's GameObject,
    which is the object's fbx 3D model.
*/
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