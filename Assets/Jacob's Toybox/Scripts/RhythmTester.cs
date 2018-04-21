using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmTester : MonoBehaviour {
    float Timer = -0.3f;
    float TimeDelay =  1f * 65/60;
    float nextHit = 0;
    float endHit = 0.2f;
    bool hasHit = false;
    public GameObject TimerObj;
    public GameObject HitterObj;
    Renderer timerRenderer;
    Renderer hitterRenderer;
    Material timerMat;
    Material hitterMat;
    // Use this for initialization
    void Start () {
         TimerObj = GameObject.Find("Timer");
    HitterObj = GameObject.Find("Hitter");
    timerRenderer = TimerObj.GetComponent<Renderer>();
        hitterRenderer = HitterObj.GetComponent<Renderer>();

        timerMat = timerRenderer.material;
        hitterMat = hitterRenderer.material;
        hitterMat.EnableKeyword("_EMISSION");
    }
	
	// Update is called once per frame
	void Update () {
        bool spaceHit = Input.GetKeyDown(KeyCode.W);

        Timer += Time.deltaTime;
        Color finalColor = Color.yellow * Mathf.LinearToGammaSpace(Timer % TimeDelay);
        Debug.Log(finalColor);
        timerMat.SetColor("_EmissionColor", finalColor);
        if (Timer > nextHit) {
            
            nextHit = nextHit + TimeDelay;
            endHit = endHit + TimeDelay;
            hitterMat.SetColor("_Color", Color.red);
            
        }

        if (spaceHit && (Timer < endHit - TimeDelay || Timer > endHit + 0.2f) )
        {
            Debug.Log("hit");
            hitterMat.SetColor("_Color", Color.blue);
        }
        else if (spaceHit){
            hitterMat.SetColor("_Color", Color.red);
        }
	}
}
