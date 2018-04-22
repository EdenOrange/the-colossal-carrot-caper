using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPrefabHiderScript : MonoBehaviour {
    GameObject[] walls;
	// Use this for initialization
	void Start () {
        walls = GameObject.FindGameObjectsWithTag("Wall");

        foreach (GameObject wall in walls)
        {
            wall.GetComponent<Renderer>().enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
