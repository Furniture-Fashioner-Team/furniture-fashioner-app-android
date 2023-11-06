using UnityEngine;
using UnityEngine.UI;

class Menu : MonoBehaviour
{
    public RectTransform scrollView;
    public RectTransform scrollViewContent;
    private Vector2 sprImgPlace;
    public Button toCamera;
    public GameObject contentPrefabComponent;

    private void Awake()
    {
        MenuFunc.ScrollViewSettings(scrollView, scrollViewContent);
        sprImgPlace = MenuFunc.GetVector2(0.55f, Global.furnitureCount - 1);
        MenuFunc.ButtonSettings(toCamera);
    }
    private void Start()
    {
        AddListItems();
    }
    private void AddListItems()
    {
        foreach (Furniture f in Global.furniture)
        {
            GameObject obj = MenuFunc.GetSprImg(sprImgPlace, contentPrefabComponent, f.spr);
            int id = f.spr.GetInstanceID();
            obj = Instantiate(obj, scrollViewContent);
            Image img = obj.GetComponent<Image>();
            MenuFunc.AddEventTrigger(obj, id, img);
            sprImgPlace.y -= Global.spriteImageSize.y * 1.1f;
            Global.furnitureDict[id] = f.obj;
        }
    }
}

/*
    This script defines the variables visible and linked to Unity: scrollView, scrollViewContent,
    toCamera and contentPrefabComponent. By cloning the latter, the necessary number of item images can
    be added to the scrollView component. One item image is always an Image object containing a Sprite.
    The size of the scrollView's content depends on how many images are added to the list. If there
    are more images than can be displayed at once, and if the content size is not defined, the list
    will not scroll. The class variable sprImgPlace is used to define the position of the first image
    on the list, as well as the subsequent images, because the value of the variable is changed
    after adding each image.
    
    In the AddListItems method, a new Image containing the Sprite of the Furniture object is created
    from the Sprite, then cloned and added to the scrollView's content. Finally, also an event listener is
    added to this cloned new object. After this, the Furniture object from the Global.furniture list is added
    to the Global.furnitureDict dictionary, so that the unique id of the Sprite object of the Furniture
    object becomes the key, and the 3D model of the item of the Furniture object becomes the value. When
    the ToCamera method is called, transition from the Menu scene to the ARCamera scene shall occur.
*/
