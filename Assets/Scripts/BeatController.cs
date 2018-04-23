using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BeatController : MonoBehaviour {
    public Image hit;
    public Image miss;
    float hitVal = 0;
    float missVal = 0;
    Color m = Color.red;
    Color h = Color.yellow;
    // Use this fstaticor initialization
    void Start () {
        hit = GameObject.Find("HitUI").GetComponent<Image>();
        miss = GameObject.Find("MissUI").GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {


            h.a = hitVal;
            hit.color = h;

            m.a = missVal;
            miss.color = m;

        if (missVal > 0) {
            missVal -= 0.1f;
        }
        if (hitVal > 0)
        {
            hitVal -= 0.1f;
        }
    }

    public void hitBeat() {
        hitVal = 1;
        missVal = 0;
    }
    public void missBeat()
    {
        missVal = 1;
        hitVal = 0;
    }
}
