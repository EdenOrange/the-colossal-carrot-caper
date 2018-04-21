using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : MonoBehaviour {
    float speed = 5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
    }

    public void SetStartingPosition(float x) {
        gameObject.transform.position += new Vector3(x, 0, 0);
    }
}
