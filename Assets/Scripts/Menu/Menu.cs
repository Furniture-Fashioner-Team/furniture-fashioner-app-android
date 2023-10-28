using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

class Menu : MonoBehaviour
{
    public RectTransform scrollView;
    public RectTransform scrollViewContent;
    private Vector2 place;
    public GameObject contentPrefabComponent;

    private void Awake()
    {
        scrollView.sizeDelta = Global.scrollViewSize;
        scrollView.anchoredPosition = new Vector2(0, Global.dim[1] * 0.05f);
        scrollViewContent.sizeDelta = MenuFunc.GetVector2(1.1f, Global.furnitureCount);
        place = MenuFunc.GetVector2(0.55f, Global.furnitureCount - 1);
    }
    private void Start()
    {
        AddListItems();
    }
    private void AddListItems()
    {
        foreach (Furniture f in Global.furniture)
        {
            GameObject obj = MenuFunc.GetSprImg(place, contentPrefabComponent, f.spr);
            int id = f.spr.GetInstanceID();
            obj = Instantiate(obj, scrollViewContent);
            Image img = obj.GetComponent<Image>();
            MenuFunc.AddEventTrigger(obj, id, img);
            place.y -= Global.spriteImageSize.y * 1.1f;
            Global.furnitureDict[id] = f.obj;
        }
    }
}

/*
    Tässä skriptissä määritellään Unityyn näkyvät ja linkittyvät muuttujat: scrollView, scrollViewContent
    ja contentPrefabComponent. Tätä viimeksi mainittua kloonaamalla voidaan scrollView-komponenttiin lisätä
    tarvittava määrä esineiden kuvia. Yksi esineen kuva on aina Image, joka sisältää Sprite:n. ScrollView:n
    sisällön koko määrittyy sen mukaan kuinka monta kuvaa listalle lisätään. Jos kuvia on enemmän kuin kerralla
    näkyviin mahtuu, ja jos sisällön kokoa ei ole määritelty, niin lista ei skrollaa. Luokkamuuttujan place
    avulla määritellään ensimmäisen kuvan paikka listalla, ja myös seuraavien kuvien, koska muuttujan arvoa
    muutetaan aina yhden kuvan lisäämisen jälkeen. AddListItems-metodissa Global.furniture-listalle luoduista
    Furniture-olioista luodaan sanakirja, jonka avaimeksi tulee Furniture-olion sisältämän Sprite-olion
    yksilöllinen id, ja jonka arvoksi tulee Furniture-olion sisältämä esineen 3D-malli. Tämän jälkeen
    Furniture-olion Sprite:stä luodaan uusi Sprite:n sisältävä Image, joka sitten kloonataan ja lisätään
    scrollView:n sisältöön, ja lopuksi tähän kloonattuun uuteen objektiin vielä lisätään tapahtuman kuuntelija.
*/
