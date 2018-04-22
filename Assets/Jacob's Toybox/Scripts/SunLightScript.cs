using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLightScript : MonoBehaviour {
    public GameObject dl;
    public float RotationSpeed = 2.0f;
    private float progress = 0f;
    Light lightComp;

    // Use this for initialization
    void Start () {
        lightComp = dl.GetComponent<Light>();
        lightComp.type = LightType.Directional;
        dl.transform.position = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        progress += RotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime));
        if (progress < 10 || progress > 40)
        {
            lightComp.color = Color.blue;

        }
        else if (progress < 20 || progress > 30)
        {
            lightComp.color = Color.yellow; 

        }
        else {
            lightComp.color = Color.white; 
        }


    }
}
