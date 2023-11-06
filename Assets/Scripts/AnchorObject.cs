using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AnchorObject : MonoBehaviour
{
    private ARAnchorManager anchorManager;
    private ARPlaneManager planeManager; // tarviiko?
    private ObjectActions objectActions;
    private ARAnchor anchor;

    void Start() 
    {
        anchorManager = GetComponent<ARAnchorManager>();
        objectActions = GetComponent<ObjectActions>();
    }

    void Update()
    {
        // ongelmana se, että tarkistaa molemmat if-ehdot jokaisella framella,
        // joten ankkuri lisätään/poistetaan myös saman kosketuksen aikana (esim. liikutettaessa)
        // muuta niin ettei heti tarkista isActivea uudestaan vaan ainoastaan silloin kun sen arvo muuttuu
        // (paitsi miten toimii metodilla?)
        // tai sit tarkista milloin touch started/canceled jne?
        // tai tee uusi bool joka seuraa isActivea

        // toinen ongelma se, että ankkuroinnin poisto/lisäys ei näytä toimivan halutusti:
        // esim. objektia näpäyttäessä (muuttuu keltaiseksi) se on edelleen paikoillaan,
        // vaikka pitäisi liikkua kameran mukana

        
        // object is not active and does not have an anchor component -> create anchor
        if (objectActions.isActive() == false && !gameObject.TryGetComponent<ARAnchor>(out anchor))
        {
            gameObject.AddComponent<ARAnchor>();
            Debug.Log("anchor added");
        }

        // object is active and has an anchor component -> remove anchor
        if (objectActions.isActive() == true && gameObject.TryGetComponent<ARAnchor>(out anchor)) 
        {
            //gameObject.RemoveComponent<ARAnchor>();
            Destroy(GetComponent<ARAnchor>());
            Debug.Log("anchor removed");
        }
    }
}
