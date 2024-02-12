using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public AudioSource AudioSource;

    // Make method to go to scene
    public void GoToScene(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    // COROUTINE
    IEnumerator LoadScene(string sceneName)
    {
        // Play sound effect
        if (AudioSource != null)
        {
            AudioSource.Play();
            // Wait 2 seconds
            yield return new WaitForSeconds(1);
        }
        // Load scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
