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
        RectTransform rT = obj.GetComponent<RectTransform>();
        rT.sizeDelta = GlobalARC.arrowLeftSize;
        rT.anchoredPosition = GlobalARC.arrowLeftPlace;
        Tuple<EventTrigger.Entry, EventTrigger> t = Global.AddClickListener(obj);
        t.Item1.callback.AddListener((_) =>
        {
            GlobalARC.aRObjDict.Values.ToList().ForEach((t) => t.inst.SetActive(false));
            SceneManager.LoadScene(Global.sceneNames[0]);
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
    public static void NewObject()
    {
        if (GlobalMenu.furnitureKey != null)
        {
            GameObject obj = GlobalMenu.furnitureDict[(int)GlobalMenu.furnitureKey];
            NewInst(obj, GlobalARC.newObjPlace, obj.transform.localRotation);
        }
    }
    public static void NewInst(GameObject obj, Vector3 plc, Quaternion rot)
    {
        GameObject inst = Instantiate(obj, plc, rot);
        BoxCollider bC = inst.AddComponent<BoxCollider>();
        AddComponents(inst);
        DontDestroyOnLoad(inst);
        GlobalARC.aRObjDict[inst.GetInstanceID()] = (obj, inst);
    }
    private static void AddComponents(GameObject obj)
    {
        ObjectActions oA = obj.AddComponent<ObjectActions>();

        ObjectColor oC = obj.AddComponent<ObjectColor>();
        oC.objActions = oA;

        MoveObject mO = obj.AddComponent<MoveObject>();
        mO.objActions = oA;

        RotateObject rO = obj.AddComponent<RotateObject>();
        rO.objActions = oA;

        ResizeObject rszO = obj.AddComponent<ResizeObject>();
        rszO.slider = GlobalARC.slider;

    }
}
