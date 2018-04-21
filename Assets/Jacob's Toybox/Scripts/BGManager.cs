using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad > 42)
        {
            Material m = gameObject.GetComponent<Renderer>().material;
            Color c = m.color;
            m.SetColor("_Color", c * ((48 - Time.timeSinceLevelLoad) / 8));
        }
    }
}
