using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLightScript : MonoBehaviour {
    public float RotationSpeed = 0.8f;
    private float progress = 0f;
    Light lightComp;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        progress += RotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime));


    }
}
