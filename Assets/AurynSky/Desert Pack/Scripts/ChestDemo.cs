using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestDemo : MonoBehaviour {

    //This script goes on the ChestComplete prefab;

    public Animator chestAnim; //Animator for the chest;

    public string sceneToLoad = "GameOver"; //The name of the scene to load;

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
        // Check if player is in front of the chest with Raycast;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2))
        {
            if (hit.collider.tag == "Player")
            {
                //play open animation;
                chestAnim.SetTrigger("open");
                //wait 2 seconds;
                StartCoroutine(GoToScene());
            }
        }
    }

    IEnumerator GoToScene()
    {
    
        // Get player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<SimpleSampleCharacterControl>().StartParticles();
        //wait 2 seconds;
        yield return new WaitForSeconds(2);
        //load the scene;
        Application.LoadLevel(sceneToLoad);
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
