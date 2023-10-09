using UnityEngine;

public class MoveObjectToFrontOfCamera : MonoBehaviour
{
    public Transform objectToMove;
    public Transform mainCamera;
    public float distanceFromCamera = 10f;

    private void Start()
    {
        if (objectToMove == null)
        {
            Debug.LogError("Object to move is not assigned!");
            enabled = false;
            return;
        }

        UnityEngine.UI.Button button = GetComponent<UnityEngine.UI.Button>();
        if (button == null)
        {
            Debug.LogError("Button component not found on this GameObject!");
            enabled = false;
            return;
        }

        button.onClick.AddListener(MoveObjectToFront);
    }

    private void MoveObjectToFront()
{
    if (objectToMove != null && mainCamera != null)
    {
        Vector3 cameraPosition = mainCamera.transform.position;
        Vector3 cameraForward = mainCamera.transform.forward;

        // Take into account the camera's rotation
        Quaternion cameraRotation = mainCamera.transform.rotation;

        // Calculate the target position in front of the camera
        Vector3 targetPosition = cameraPosition + cameraRotation * Vector3.forward * distanceFromCamera;

        objectToMove.position = targetPosition;
    }
    else
    {
        Debug.LogError("Object to move or mainCamera is null in MoveObjectToFront!");
    }
}
}