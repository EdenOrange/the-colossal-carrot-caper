using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour {
    float Timer = 0;
    bool mouseClick;
    bool spaced;
    List<float> times = new List<float>();
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Timer += Time.deltaTime;
        mouseClick = Input.GetMouseButtonDown(0);
        spaced = Input.GetKeyDown(KeyCode.Space);
        if (mouseClick) {
            times.Add(Timer);
            Debug.Log(Timer);
        }
        if (spaced) {
            printArray(times);
        }

	}
    public void printArray(List<float> a)
    {
        string stringToOut = "0, ";
        foreach (var i in a)
        {
            stringToOut += i.ToString("0.0000") + ", ";
        }
        Debug.Log(stringToOut);
    }
}
