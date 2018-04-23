using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatFadeController : MonoBehaviour {
    Image fade;
    float fadeVal;
	// Use this for initialization
	void Start () {
        fade = gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.beatsSinceHit > 3)
        {
            Color c = Color.black;
            fadeVal += 0.142f * Time.deltaTime;
            c.a = Mathf.Lerp(c.a, fadeVal,1);
            fade.color = c;
        }
        else {
            Color c = Color.black;
            fadeVal = 0;
            c.a = 0;
            fade.color = c;
        }
	}
}
