using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class ARCameraFunc : MonoBehaviour
{
    public static void ArrowLeftSettings(GameObject obj)
    {
        Global.UICompSizeAndPlace(obj, GlobalARC.iconSize, GlobalARC.arrowLeftPlace);
        Tuple<EventTrigger.Entry, EventTrigger> t = Global.AddClickListener(obj);
        t.Item1.callback.AddListener((_) =>
        {
            GlobalARC.aRObjDict.Values.ToList().ForEach((t) => t.inst.SetActive(false));
            SceneManager.LoadScene(Global.sceneNames[0]);
        });
        t.Item2.triggers.Add(t.Item1);
    }
    public static void TrashCanSettings(GameObject obj)
    {
        Global.UICompSizeAndPlace(obj, GlobalARC.iconSize, GlobalARC.trashCanPlace);
        Tuple<EventTrigger.Entry, EventTrigger> t = Global.AddClickListener(obj);
         t.Item1.callback.AddListener((_) =>
        {
            Destroy(GlobalARC.aRObjDict[(int)GlobalARC.aRObjKey].Item2);
            GlobalARC.aRObjDict.Remove((int)GlobalARC.aRObjKey);
            GlobalARC.aRObjKey = null;
        });
        t.Item2.triggers.Add(t.Item1);
    }
    public static void OldARObjects()
    {
        if (GlobalARC.aRObjDict.Count > 0)
        {
            GlobalARC.aRObjDict.Values.ToList().ForEach((t) => t.inst.SetActive(true));
        }
    }
    public static void NewObject(GameObject prefab, Slider slider)
    {
        if (GlobalMenu.furnitureKey != null)
        {
            GameObject obj = GlobalMenu.furnitureDict[(int)GlobalMenu.furnitureKey];
            NewInst(obj, GlobalARC.newObjPlace, obj.transform.localRotation,
                obj.transform.localScale, prefab, slider);
        }
    }
    public static void NewInst(GameObject obj, Vector3 plc, Quaternion rt,
        Vector3 scl, GameObject prefab, Slider sld)
    {
        GameObject inst = Instantiate(prefab, plc, rt);
        inst.transform.localScale = scl;
        MeshFilter pMF = inst.GetComponent<MeshFilter>();
        MeshRenderer pMR = inst.GetComponent<MeshRenderer>();
        MeshFilter oMF = obj.GetComponent<MeshFilter>();
        MeshRenderer oMR = obj.GetComponent<MeshRenderer>();
        pMF.sharedMesh = oMF.sharedMesh;
        pMR.sharedMaterials = oMR.sharedMaterials;
        BoxCollider bC = inst.AddComponent<BoxCollider>();
        ResizeObject rsO = inst.AddComponent<ResizeObject>();       // Tämä pitää ehkä siirtää globaalimalle tasolle,
        rsO.slider = sld;                                           // jotta toimii aina aktiiviselle esineelle!
        DontDestroyOnLoad(inst);
        GlobalARC.aRObjDict[inst.GetInstanceID()] = (obj, inst);
    }
}
