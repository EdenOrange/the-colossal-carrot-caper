using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitSpriteScript : MonoBehaviour {
    Image hitSprite;

	// Use this for initialization
	void Start () {
        hitSprite = GameObject.Find("HitSprite").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        Color c = hitSprite.color;
        c.a = 1 - ManagerGlobalVars.TimeSinceHit;
        hitSprite.color = c;

    }
}
