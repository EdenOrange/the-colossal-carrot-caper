using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatBarScript : MonoBehaviour {
    public float beatTime = 60/88f;
    public Transform beatTick;
    float currentTime = 0f;
    float nextBeat = 0f;
    public GameObject TickHolder;
    public GameObject canvas;
	// Use this for initialization
	void Start () {
        beatTime = 60/88f;
        TickHolder = GameObject.Find("TickHolder");
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;

        if (currentTime > nextBeat) {
            Transform left = Instantiate(beatTick, new Vector3(0, 0, 0), Quaternion.identity, TickHolder.transform);
            Transform right = Instantiate(beatTick, new Vector3(0, 0, 0) , Quaternion.identity, TickHolder.transform);
            left.gameObject.GetComponent<RectTransform>().position = new Vector3(-75, 95, 0);
            right.gameObject.GetComponent<RectTransform>().position = new Vector3(Screen.width+75, 95, 0);
            nextBeat += beatTime;
            GameManager.beatsSinceHit++;
        }
	}
}
