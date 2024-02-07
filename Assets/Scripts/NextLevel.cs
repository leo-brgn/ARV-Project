using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    // This class check if the user taps on the GameObject on mobile screen
    // If the user taps on the current GameObject, the game will load the next level

    void Update()
    {
        // Check if there is at least one touch
        if (Input.touchCount > 0)
        {
            // Get the first touch
            Touch touch = Input.GetTouch(0);

            // Check if it's the beginning of the touch
            if (touch.phase == TouchPhase.Began)
            {
                // Get the touch position
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                // Check if the user taps on the current GameObject with Box Collider 3D with margin of error of 0.5f
                if (GetComponent<BoxCollider>().bounds.Contains(touchPosition))
                {
                    // Load the next level
                    UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
                }
            }
        }
    }
}
