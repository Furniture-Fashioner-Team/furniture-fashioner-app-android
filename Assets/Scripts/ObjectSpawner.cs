using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectPrefabs;  // Array of different objects to spawn.
    public Button[] buttons;           // Array of UI buttons corresponding to the objects.
    public float spawnOffsetZ = 5f;    // Offset in the z-direction.

    private Dictionary<int, GameObject> instantiatedObjects = new Dictionary<int, GameObject>();

    private void Start()
    {
        // Attach button click listeners.
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Capture the current button's index.
            buttons[i].onClick.AddListener(() => SpawnObject(index));
        }
    }

    public void SpawnObject(int index)
    {
        // Check if an object is already instantiated for this button.
        if (!instantiatedObjects.ContainsKey(index))
        {
            // Calculate the spawn position with an offset in the z-direction.
            Vector3 spawnPosition = transform.position + new Vector3(0f, 0f, spawnOffsetZ);

            // Instantiate the corresponding object at the calculated position.
            GameObject instantiatedObject = Instantiate(objectPrefabs[index], spawnPosition, Quaternion.identity);

            // Store the instantiated object in the dictionary.
            instantiatedObjects[index] = instantiatedObject;
        }
    }
}