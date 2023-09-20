using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private Transform obj; // moveable object
    private bool isMoved = false; // whether the object is being moved or not
    private float distance; // distance between the camera and object (the object is only moved within XY axis)
    private Vector3 offset; // offset between the original and moved position
    private Color objColor = new Color(); // sets the object color for testing purposes

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 coordinates; // a helper variable for storing positions

        // the object is only moved when the screen is touched once,
        // otherwise the event is canceled
        if (Input.touchCount != 1) {
            isMoved = false;
            objColor = Color.white;
            return;
        }

        Touch screenTouch = Input.touches[0]; // 1st touch of the screen
        Vector3 touchPosition = screenTouch.position; // for storing the screen touch position

        // the event triggers when the touch phase is started:
        // raycast check if there is an object at the coordinates of the screen touch
        if (screenTouch.phase == TouchPhase.Began) {
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                // if the raycast hits anything with the tag "object", 
                // it stores the object position and offset
                // and sets isMoved to true
                if (hit.collider.tag == "object") {
                    obj = hit.transform;
                    distance = hit.transform.position.z - Camera.main.transform.position.z;
                    coordinates = new Vector3(touchPosition.x, touchPosition.y, distance);
                    coordinates = Camera.main.ScreenToWorldPoint(coordinates);
                    offset = obj.position - coordinates;
                    isMoved = true;
                    objColor = Color.blue;
                }
            }
        }

        // the actual moving of the object happens here
        if (isMoved && screenTouch.phase == TouchPhase.Moved) {
            coordinates = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            coordinates = Camera.main.ScreenToWorldPoint(coordinates);
            obj.position = coordinates + offset;
        }

        // if the movement is canceled or ended, isMoved is set back to false
        if (isMoved && (screenTouch.phase == TouchPhase.Ended || screenTouch.phase == TouchPhase.Canceled)) {
            isMoved = false;
            objColor = Color.white;
        }

        // renders the object's color according to isMoved (testing)
        GetComponent<MeshRenderer>().material.color = objColor;
        
    }
}
