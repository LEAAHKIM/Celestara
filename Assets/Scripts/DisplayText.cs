using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayText : MonoBehaviour
{
    public GameObject gem;
    public string sceneName;

    void Update()
    {
        if (gem == null)
        {
            StartCoroutine(LoadSceneAfterDelay(1.5f));
        }
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Debug.Log("Attempting to load new scene: " + sceneName);

        // check if the scene is in build settings
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene " + sceneName + " cannot be loaded. Ensure it is added to the build settings.");
        }
    }
}
