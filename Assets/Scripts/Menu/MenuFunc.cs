using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

class MenuFunc
{
    public static Vector2 GetVector2(float mod, int n)
    {
        return new Vector2(0, Global.spriteImageSize.y * mod * n);
    }
    public static GameObject GetSprImg(Vector2 place, GameObject prefab, Sprite spr)
    {
        Image spriteImage = prefab.GetComponent<Image>();
        spriteImage.sprite = spr;
        spriteImage.rectTransform.sizeDelta = Global.spriteImageSize;
        spriteImage.rectTransform.anchoredPosition = place;
        return prefab;
    }
    public static void AddEventTrigger(GameObject obj, int id, Image img)
    {
        EventTrigger eT = obj.AddComponent<EventTrigger>();
        EventTrigger.Entry e = new EventTrigger.Entry();
        e.eventID = EventTriggerType.PointerClick;
        e.callback.AddListener((_) =>
        {
            RemovePreviousSelection();
            SetFurnitureKey(id);
            SetSelectedImage(img);
        });
        eT.triggers.Add(e);
    }
    private static void RemovePreviousSelection()
    {
        if (Global.selectedImage != null)
        {
            SetOpacity(Global.selectedImage, 1f);
            Global.selectedImage = null;
        }
    }
    private static void SetFurnitureKey(int id)
    {
        Global.furnitureKey = Global.furnitureKey != id ? id : null;
    }
    private static void SetSelectedImage(Image img)
    {
        if (Global.furnitureKey != null)
        {
            SetOpacity(img, 0.5f);
            Global.selectedImage = img;
        }
    }
    private static void SetOpacity(Image img, float opacity)
    {
        Color col = img.color;
        col.a = opacity;
        img.color = col;
    }
}
