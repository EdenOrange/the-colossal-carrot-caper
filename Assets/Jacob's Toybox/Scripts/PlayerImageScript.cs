using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImageScript : MonoBehaviour {
    float jump = 0;
	// Use this for initialization
	void Start () {
        //Debug.Log(jump);
    }
	
	// Update is called once per frame
	void Update () {
        jump = Time.time % 5;
        //Debug.Log(jump);
        Vector3 newPos = new Vector3(gameObject.transform.position.x, 50, 0 );

        newPos.y = (((jump - 2.5f) *(jump -2.5f))  * ManagerGlobalVars.Energy) * 2  + 50;
        gameObject.transform.position = newPos;
	}
}
