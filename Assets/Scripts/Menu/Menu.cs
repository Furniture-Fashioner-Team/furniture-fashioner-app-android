using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

class Menu : MonoBehaviour
{
    public RectTransform scrollView;
    public RectTransform scrollViewContent;
    private Vector2 place;
    public GameObject contentPrefabComponent;

    private void Awake()
    {
        scrollView.sizeDelta = Data.scrollViewSize;
        scrollView.anchoredPosition = new Vector2(0, Data.dim[1] * 0.05f);
        scrollViewContent.sizeDelta = MenuFunc.GetVector2(1.1f, Data.furnitureCount);
        place = MenuFunc.GetVector2(0.55f, Data.furnitureCount - 1);
    }
    private void Start()
    {
        AddListItems();
    }
    private void AddListItems()
    {
        foreach (Furniture f in Data.furniture)
        {
            Data.furnitureDict[f.spr.GetInstanceID()] = f.obj;
            GameObject obj = MenuFunc.GetSprImg(place, contentPrefabComponent, f.spr);
            obj = Instantiate(obj, scrollViewContent);
            MenuFunc.AddEventTrigger(obj, f.spr.GetInstanceID());
            place.y -= Data.spriteImageSize.y * 1.1f;
        }
    }
}
