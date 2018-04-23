using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScript : MonoBehaviour {
    RectTransform rt;
	// Use this for initialization
	void Start () {
        rt = gameObject.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(rt.position.x);
        if (rt.position.x < Screen.width / 2 - 3)
        {
            Vector3 newpos = new Vector3(210, 0, 0);
            rt.position = rt.position + (newpos * Time.deltaTime) ;
            

        }
        else if (transform.position.x > Screen.width / 2 +3)
        {
            Vector3 newpos = new Vector3(-210, 0, 0);
            rt.position = rt.position + (newpos * Time.deltaTime);
        }
        else {
            // trigger beat
            Destroy(gameObject);
        }


        }
    }

