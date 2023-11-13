using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

class MenuFunc
{
    public static void ScrollViewSettings(RectTransform rT, RectTransform rTCont)
    {
        rT.sizeDelta = GlobalMenu.scrollViewSize;
        rT.anchoredPosition = new Vector2(0, Global.dim[1] * 0.05f);
        rTCont.sizeDelta = GetVector2(1.1f, GlobalMenu.furnitureCount);
    }
    public static void ButtonSettings(Button b)
    {
        RectTransform rT = b.GetComponent<RectTransform>();
        rT.sizeDelta = GlobalMenu.toCameraSize;
        rT.anchoredPosition = GlobalMenu.toCameraPlace;
        rT.GetComponentInChildren<TextMeshProUGUI>().fontSize = GlobalMenu.toCameraFontSize;
        b.onClick.AddListener(() => SceneManager.LoadScene(Global.sceneNames[1]));
    }
    public static Vector2 GetVector2(float mod, int n)
    {
        return new Vector2(0, GlobalMenu.spriteImageSize.y * mod * n);
    }
    public static GameObject GetSprImg(Vector2 place, GameObject prefab, Sprite spr)
    {
        Image spriteImage = prefab.GetComponent<Image>();
        spriteImage.sprite = spr;
        spriteImage.rectTransform.sizeDelta = GlobalMenu.spriteImageSize;
        spriteImage.rectTransform.anchoredPosition = place;
        return prefab;
    }
    public static void AddEventTrigger(GameObject obj, int id, Image img)
    {
        Tuple<EventTrigger.Entry, EventTrigger> t = Global.AddClickListener(obj);
        t.Item1.callback.AddListener((_) =>
        {
            RemovePreviousSelection();
            SetFurnitureKey(id);
            SetSelectedImage(img);
        });
        t.Item2.triggers.Add(t.Item1);
    }
    private static void RemovePreviousSelection()
    {
        if (GlobalMenu.selectedImage != null)
        {
            SetOpacity(GlobalMenu.selectedImage, 1f);
            GlobalMenu.selectedImage = null;
        }
    }
    private static void SetFurnitureKey(int id)
    {
        GlobalMenu.furnitureKey = GlobalMenu.furnitureKey != id ? id : null;
    }
    private static void SetSelectedImage(Image img)
    {
        if (GlobalMenu.furnitureKey != null)
        {
            SetOpacity(img, 0.5f);
            GlobalMenu.selectedImage = img;
        }
    }
    private static void SetOpacity(Image img, float opacity)
    {
        Color col = img.color;
        col.a = opacity;
        img.color = col;
    }
}

/*
    The MenuFunc class of this script contains helper methods used by the Menu class
    of the Menu script. ButtonSettings programmatically sets the size and font size
    of the toCamera button. ScrollViewSettings programmatically sets the size and font size
    of the scrollView and scrollViewContent components. GetVector2 returns the desired
    2-dimensional vector. GetSprImg returns the prefab component to which a specific item's
    image sprite has been added. AddEventTrigger adds an event listener to the cloned
    image-containing prefab component, which allows modification of the GlobalMenu.furnitureKey
    variable's value and, on the other hand, the transparency of the 'clicked' menu image,
    so that the user knows which item is selected. The remaining methods are helper methods
    for AddEventTrigger.
*/
