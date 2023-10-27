using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

class MenuFunc
{
    public static Vector2 GetVector2(float mod, int n)
    {
        return new Vector2(0, Data.spriteImageSize.y * mod * n);
    }
    public static GameObject GetSprImg(Vector2 place, GameObject prefab, Sprite spr)
    {
        Image spriteImage = prefab.GetComponent<Image>();
        spriteImage.sprite = spr;
        spriteImage.rectTransform.sizeDelta = Data.spriteImageSize;
        spriteImage.rectTransform.anchoredPosition = place;
        return prefab;
    }
    public static void AddEventTrigger(GameObject obj, int id)
    {
        EventTrigger eT = obj.AddComponent<EventTrigger>();
        EventTrigger.Entry e = new EventTrigger.Entry();
        e.eventID = EventTriggerType.PointerClick;
        e.callback.AddListener((data) => { Test(id); });
        eT.triggers.Add(e);
    }
    private static void Test(int id)
    {
        Debug.Log(Data.furnitureDict[id]);
    }
}
