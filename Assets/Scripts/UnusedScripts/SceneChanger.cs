using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName; // The name of the scene you want to switch to.

    public void ChangeScene()
    {
        Debug.Log("Button clicked. Changing scene to " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}