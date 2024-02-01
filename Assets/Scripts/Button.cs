using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    // Make method to go to scene
    public void GoToScene(string sceneName)
    {
        // Load scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
