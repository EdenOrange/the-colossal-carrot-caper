using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GridPlayerController : MonoBehaviour {
    float timer = 0;
    //GameObject beat;

    //GameObject goal;
    AudioSource song;
    bool caught;

    PlayerState playerState;


    // Use this for initialization
    void Start () {
        //goal = GameObject.Find("Goal");
        //beat = GameObject.Find("Beat");
        song = gameObject.GetComponent<AudioSource>();
        //song.time = 16;
        song.Play();
        caught = false;
        playerState = GetComponent<PlayerState>();
    }

	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        float currentTime = ((timer ) % 0.66f);
        bool moveable = currentTime < 0.15f  || currentTime > 0.51f;

        /*
        if (moveable)
        {
            beat.active = true;
        }
        else {
            beat.active = false;
        }*/

        if (playerState.goal)
        {
            return;
        }

        bool w = Input.GetKeyDown(KeyCode.W);
        bool a = Input.GetKeyDown(KeyCode.A);
        bool s = Input.GetKeyDown(KeyCode.S);
        bool d = Input.GetKeyDown(KeyCode.D);

        
        Vector3 target = new Vector3(0,0,0);

        if (w && moveable) {
            target = new Vector3(0, 0, 1) + target;
        }
        if (a && moveable)
        {
            target = new Vector3(-1, 0, 0) + target;
        }
        if (s && moveable)
        {
            target = new Vector3(0, 0, -1) + target;
        }
        if (d && moveable)
        {
            target = new Vector3(1, 0, 0) + target;          

        }
        RaycastHit hit;
        bool lookAhead = Physics.Raycast(transform.position, transform.TransformDirection(target), out hit, 1);


        // Does the ray intersect any objects excluding the player layer
        if (lookAhead && hit.transform.tag == "Wall")
        {
            //play wall hit sound
        }
        else if (lookAhead&& hit.transform.tag == "Collectible" )
        {
            target += gameObject.transform.position;
            gameObject.transform.position = target;
            //do collect stuff here
            // Destroy(hit.transform.gameObject);
        }
        else if (lookAhead && hit.transform.tag == "Goal")
        {
            target += gameObject.transform.position;
            gameObject.transform.position = target;
            //do goal stuff here stuff here
            // Destroy(hit.transform.gameObject);
        }
        else if (lookAhead && hit.transform.tag == "Ground")
        {
            //jump sound and move
            target += gameObject.transform.position;
            gameObject.transform.position = target;
        }
        

    }

    public void CaughtByEnemy()
    {
        if (!caught)
       {
            GameManager.Instance.Lose();
       }
        caught = true;
    }
}
