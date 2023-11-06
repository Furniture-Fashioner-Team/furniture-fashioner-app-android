using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class ARCameraFunc
{
    public static void ArrowLeftSettings(GameObject obj)
    {
        RectTransform rT = obj.GetComponent<RectTransform>();
        rT.sizeDelta = Global.arrowLeftSize;
        rT.anchoredPosition = Global.arrowLeftPlace;
        EventTrigger eT = obj.AddComponent<EventTrigger>();
        EventTrigger.Entry e = new EventTrigger.Entry();
        e.eventID = EventTriggerType.PointerClick;
        e.callback.AddListener((_) => SceneManager.LoadScene(Global.sceneNames[0]));
        eT.triggers.Add(e);
    }
}
