using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Billboard : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.rotation = Camera.main.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
