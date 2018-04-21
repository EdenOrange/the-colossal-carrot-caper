using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GridPlayerController : MonoBehaviour {
    float timer = 0;
    GameObject beat;
    // Use this for initialization
    void Start () {
        beat = GameObject.Find("Beat");
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        bool moveable = ((timer + 0.1) % 0.5) < 0.3f;


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
        if (w && moveable) {
            Vector3 target = new Vector3(0, 0, 1) + gameObject.transform.position;
            gameObject.transform.position = target;

        }
        if (a && moveable)
        {
            Vector3 target = new Vector3(-1, 0, 0) + gameObject.transform.position;
            gameObject.transform.position = target;

        }
        if (s && moveable)
        {
            Vector3 target = new Vector3(0, 0, -1) + gameObject.transform.position;
            gameObject.transform.position = target;

        }
        if (d && moveable)
        {
            Vector3 target = new Vector3(1, 0, 0) + gameObject.transform.position;
            gameObject.transform.position = target;

        }
    }
}
