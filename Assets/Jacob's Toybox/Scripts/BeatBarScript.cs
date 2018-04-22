using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatBarScript : MonoBehaviour {
    public float beatTime = 0.66667f;
    public Transform beatTick;
    float currentTime = 0f;
    float nextBeat = 0f;
    public GameObject canvas;
	// Use this for initialization
	void Start () {
        beatTime = 0.66f;
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;

        if (currentTime > nextBeat) {
            Transform left = Instantiate(beatTick, new Vector3(0, 0, 0), Quaternion.identity, canvas.transform);
            Transform right = Instantiate(beatTick, new Vector3(0, 0, 0) , Quaternion.identity,canvas.transform);
            left.gameObject.GetComponent<RectTransform>().position = new Vector3(-60, 95, 0);
            right.gameObject.GetComponent<RectTransform>().position = new Vector3(Screen.width+60, 95, 0);
            nextBeat += beatTime;
        }
	}
}
