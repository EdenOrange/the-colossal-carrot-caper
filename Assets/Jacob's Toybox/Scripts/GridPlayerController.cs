using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GridPlayerController : MonoBehaviour {
    float timer = 0;
    GameObject beat;
    AudioSource song;
    bool detected;
    // Use this for initialization
    void Start () {
        beat = GameObject.Find("Beat");
        song = gameObject.GetComponent<AudioSource>();
        //song.time = 16;
        song.Play();
        detected = false;

    }

	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        float currentTime = ((timer ) % 0.33f);
        bool moveable = currentTime < 0.12f  || currentTime > 0.20f;


        if (moveable)
        {
            beat.active = true;
        }
        else {
            beat.active = false;
        }

        bool w = Input.GetKeyDown(KeyCode.W);
        bool a = Input.GetKeyDown(KeyCode.A);
        bool s = Input.GetKeyDown(KeyCode.S);
        bool d = Input.GetKeyDown(KeyCode.D);

        RaycastHit hit;
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
        bool lookAhead = Physics.Raycast(transform.position, transform.TransformDirection(target), out hit, 1);
        

        // Does the ray intersect any objects excluding the player layer
        if (!lookAhead)
        {
            target += gameObject.transform.position;
            gameObject.transform.position = target;
        }
        if (lookAhead&& hit.transform.tag == "Collectible" )
        {
            target += gameObject.transform.position;
            gameObject.transform.position = target;
            //do collect stuff here
            Destroy(hit.transform.gameObject);
        }

    }

    public void DetectedByEnemy()
    {
        if (!detected)
        {
            GameManager.Instance.Lose();
        }
        detected = true;
    }
}
