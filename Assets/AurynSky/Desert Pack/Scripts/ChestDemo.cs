using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDemo : MonoBehaviour {

    //This script goes on the ChestComplete prefab;

    public Animator chestAnim; //Animator for the chest;

    public string sceneToLoad = "GameOver"; //The name of the scene to load;

    // Audio clip of opening
    public AudioClip OpenSound;

	// Use this for initialization
	void Awake ()
    {
        //get the Animator component from the chest;
        chestAnim = GetComponent<Animator>();
        //start opening and closing the chest for demo purposes;
        // StartCoroutine(OpenCloseChest());
	}

    void Update()
    {
        // Send a ray to test if player is in front of the chest;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 4f))
        {
            if (hit.collider.tag == "Player")
            {
                StartCoroutine(GoToScene());
            }
        }
    }

    IEnumerator GoToScene()
    {
    
        // Get player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<SimpleSampleCharacterControl>().StartParticles();
        // Start sound clip
        AudioSource.PlayClipAtPoint(OpenSound, transform.position);
        //wait 2 seconds;
        yield return new WaitForSeconds(2);
        //load the scene;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }

    IEnumerator OpenCloseChest()
    {
        //play open animation;
        chestAnim.SetTrigger("open");
        //wait 2 seconds;
        yield return new WaitForSeconds(2);
        //play close animation;
        chestAnim.SetTrigger("close");
        //wait 2 seconds;
        yield return new WaitForSeconds(2);
        //Do it again;
        StartCoroutine(OpenCloseChest());
    }
}
