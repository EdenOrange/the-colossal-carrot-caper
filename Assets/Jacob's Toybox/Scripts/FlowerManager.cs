using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 tar = new Vector3(1,-1,1);
        tar = tar * (ManagerGlobalVars.Score + 1) / 25000 * 10;
        gameObject.transform.localScale = tar;
        
	}
}
