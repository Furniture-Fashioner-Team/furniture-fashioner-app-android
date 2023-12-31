using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*
    The ARCameraFunc class of this script contains helper functions used by the ARCamera class
    within the ARCamera script. The MenuIconSettings, TrashCanSettings, and DuplicateSettings
    functions define the properties of corresponding augmented reality camera view UI components,
    and all of the aforementioned functions utilize the UICompSizeAndPlace function, which determines
    the size and position of a specific component. The NewInst function is a helper function for the
    NewObject function, used to add a desired new item instance.
*/
class ARCameraFunc : MonoBehaviour
{
    public static void MenuIconSettings(GameObject obj)
    {
        UICompSizeAndPlace(obj, GlobalARC.iconSize, GlobalARC.menuIconPlace);
        Tuple<EventTrigger.Entry, EventTrigger> t = Global.AddClickListener(obj);
        t.Item1.callback.AddListener((_) =>
        {
            GlobalARC.aRObjDict.Values.ToList().ForEach((inst) => inst.SetActive(false));
            SceneManager.LoadScene(Global.sceneNames[1]);
        });
        t.Item2.triggers.Add(t.Item1);
    }
    public static void TrashCanSettings(GameObject obj)
    {
        UICompSizeAndPlace(obj, GlobalARC.iconSize, GlobalARC.trashCanPlace);
        Tuple<EventTrigger.Entry, EventTrigger> t = Global.AddClickListener(obj);
        t.Item1.callback.AddListener((_) =>
       {
           Destroy(GlobalARC.aRObjDict[(int)GlobalARC.aRObjKey]);
           GlobalARC.aRObjDict.Remove((int)GlobalARC.aRObjKey);
           GlobalARC.aRObjKey = null;

           AudioClip deleteAudioClip = Resources.Load<AudioClip>("Sounds/opo");
           AudioSource audioSource = Camera.main.GetComponent<AudioSource>();
           audioSource.clip = deleteAudioClip;
           audioSource.Play();
       });
        t.Item2.triggers.Add(t.Item1);
    }
    public static void DuplicateSettings(GameObject obj)
    {
        UICompSizeAndPlace(obj, GlobalARC.iconSize, GlobalARC.duplicatePlace);
        Tuple<EventTrigger.Entry, EventTrigger> t = Global.AddClickListener(obj);
        t.Item1.callback.AddListener((_) =>
       {
           GameObject inst = GlobalARC.aRObjDict[(int)GlobalARC.aRObjKey];
           Vector3 place = inst.transform.position;
           Vector3 newPlace = new Vector3(place.x - 0.2f, place.y, place.z);
           GameObject dup = Instantiate(inst, newPlace, inst.transform.localRotation);
           DontDestroyOnLoad(dup);
           GlobalARC.aRObjDict[dup.GetInstanceID()] = dup;

           AudioClip duplicateAudioClip = Resources.Load<AudioClip>("Sounds/pop");
           AudioSource audioSource = Camera.main.GetComponent<AudioSource>();
           audioSource.clip = duplicateAudioClip;
           audioSource.Play();
       });
        t.Item2.triggers.Add(t.Item1);
    }
    public static void UICompSizeAndPlace(GameObject obj, Vector2 size, Vector2 place)
    {
        RectTransform rT = obj.GetComponent<RectTransform>();
        rT.sizeDelta = size;
        rT.anchoredPosition = place;
    }
    public static void OldARObjects()
    {
        if (GlobalARC.aRObjDict.Count > 0)
        {
            GlobalARC.aRObjDict.Values.ToList().ForEach((inst) => inst.SetActive(true));
        }
    }
    public static void NewObject(GameObject prefab)
    {
        if (GlobalMenu.furnitureKey != null)
        {
            GameObject obj = GlobalMenu.furnitureDict[(int)GlobalMenu.furnitureKey];
            NewInst(obj, GlobalARC.newObjPlace, obj.transform.localRotation,
                obj.transform.localScale, prefab);
        }
    }
    private static void NewInst(GameObject obj, Vector3 plc, Quaternion rt,
        Vector3 scl, GameObject prefab)
    {
        plc = new Vector3(plc.x, plc.y + 0.01f*obj.transform.localScale.y/2, plc.z);
        GameObject inst = Instantiate(prefab, plc, rt);
        inst.transform.localScale = scl;
        MeshFilter iMF = inst.GetComponent<MeshFilter>();
        MeshRenderer iMR = inst.GetComponent<MeshRenderer>();
        MeshFilter oMF = obj.GetComponent<MeshFilter>();
        MeshRenderer oMR = obj.GetComponent<MeshRenderer>();
        iMF.sharedMesh = oMF.sharedMesh;
        iMR.sharedMaterials = oMR.sharedMaterials;
        BoxCollider bC = inst.AddComponent<BoxCollider>();
        DontDestroyOnLoad(inst);
        GlobalARC.aRObjDict[inst.GetInstanceID()] = inst;
    }
}
