using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour {
    float Timer = 0;
    bool mouseClick;
    bool spaced;
    bool left;
    bool right;
    List<float> times = new List<float>();
    List<char> keys = new List<char>();
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Timer += Time.deltaTime;
        mouseClick = Input.GetMouseButtonDown(0);
        spaced = Input.GetKeyDown(KeyCode.Space);
        left = Input.GetKeyDown(KeyCode.LeftArrow);
        right = Input.GetKeyDown(KeyCode.RightArrow);
        if (mouseClick) {
            times.Add(Timer);
            Debug.Log(Timer);
        }
        if (left)
        {
            times.Add(Timer);
            keys.Add('L');
            Debug.Log(Timer);
        }
        if (right)
        {
            times.Add(Timer);
            keys.Add('R');
            Debug.Log(Timer);
        }
        if (spaced) {
            printArray(times);
            printArray(keys);

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
    public void printArray(List<char> a)
    {
        string stringToOut = "0, ";
        foreach (var i in a)
        {
            stringToOut += i + ", ";
        }
        Debug.Log(stringToOut);
    }
}
