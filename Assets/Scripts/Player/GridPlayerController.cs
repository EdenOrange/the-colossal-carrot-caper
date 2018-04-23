using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GridPlayerController : MonoBehaviour {
    float timer = 0;
    AudioSource song;
    bool caught;
    PlayerState playerState;
    Vector3 destination;
    

    // Use this for initialization
    void Start () {
        song = gameObject.GetComponent<AudioSource>();
        song.Play();
        caught = false;
        playerState = GetComponent<PlayerState>();

        destination = gameObject.transform.position;
    }

	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        float currentTime = ((timer ) % 0.6667f);
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
        if ((w || a || s || d) && !moveable) {

            GameManager.beatsSinceHit++;
            AudioManager.Instance.PlaySfxMissedBeat();
            
        }
        if (w && moveable)
        {
            target = new Vector3(0, 0, 1) + target;
            GameManager.beatsSinceHit = 0;
        }
        else if (a && moveable)
        {
            target = new Vector3(-1, 0, 0) + target;
            GameManager.beatsSinceHit = 0;
        }
        else if (s && moveable)
        {
            target = new Vector3(0, 0, -1) + target;
            GameManager.beatsSinceHit = 0;
        }
        else if (d && moveable)
        {
            target = new Vector3(1, 0, 0) + target;
            

        }

            RaycastHit hit;
        bool lookAhead = Physics.Raycast(transform.position, transform.TransformDirection(target), out hit, 1);


        // Does the ray intersect any objects excluding the player layer
        if (lookAhead && hit.transform.tag != "Wall")
        {
            target += destination;
            destination = target;
            GameManager.beatsSinceHit = 0;
        }
        else if (lookAhead && hit.transform.tag == "Wall")
        {
            Camera.main.GetComponent<CameraShake>().shakeDuration = 0.05f;
            //play wall hit sound
            // Destroy(hit.transform.gameObject);
        }


        if (transform.position != destination) {
            transform.position = Vector3.Lerp(transform.position, destination, 16.0f * Time.deltaTime);
        }


        if (GameManager.beatsSinceHit > 15) {
            GameManager.Instance.Lose();
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
