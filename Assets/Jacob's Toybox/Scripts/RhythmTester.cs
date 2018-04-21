using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmTester : MonoBehaviour {
    float Timer = 0f;
    float TimeDelay =  1f * 65/60;
    float nextHit = 0;
    float lastHit = 0.2f;
    float latency = 0.3f;
    float reset;

    bool hasHit = false;
    GameObject TimerObj;
    GameObject HitterObj;
    Renderer timerRenderer;
    Renderer hitterRenderer;
    Material timerMat;
    Material hitterMat;
    GameObject thing;
    int count;
    float[] nums;
    bool triggered;


    // Use this for initialization
    void Start () {
        GameObject thing = GameObject.Find("RhythmBlock");
        string f = "0, 1.8908, 2.9015, 3.8788, 4.8397, 5.8502, 6.9273, 7.9045, 8.8819, 9.9093, 10.9197, 11.9633, 12.9407, 13.9182, 14.9462, 15.9727, 16.9665, 17.9439, 18.9710, 19.9487, 20.9294, 21.9567, 22.9343, 23.8621, 24.8723, 25.8995, 26.9478, 27.9915, 28.9525, 30.0458, 30.9735, 32.0217, 33.1151, 34.0760, 34.7221, 35.1197, 35.5173, 36.0143, 36.5113, 36.9918, 37.4888, 38.0189, 38.4498, 38.9471, 39.4768, 39.9904, 40.4377, 40.9514, 41.4980, 41.9950, 42.4754, 42.9927, 43.4733, 43.9869, 44.4344, 44.8979, 45.3949, 45.9582, 46.4386, 47.0019, 47.4824, 48.0291, 48.4764, 49.0067, 49.5533, 50.0668, 50.5309, 51.0443, 51.5247, 52.0714, 52.5021, 52.8997, 53.4133, 53.9931, 54.5233, 54.9872, 55.5173, 56.1137, 56.5445, 57.0746, 57.5716, 58.1183, 58.5656, 59.1123, 59.6591, 60.1229, 60.6531, 61.2329, 61.6305, 62.1607, 62.6248, 63.1713, 63.6517, 64.1818, 64.6789, 65.1261, 65.6728, 66.1697, 67.1968, 68.2242, 69.1452, 70.2881, 71.2821, 72.1767, 73.1540, 74.1977, 75.2579, 76.2191, 77.2292, 78.3059, 79.2501, 80.2491, 81.2762, 82.3364, 83.3304, 84.2415, 85.3514, 86.2728, 87.2665, 88.2452, 89.2378, 90.2152, 91.1988, 92.2756, 93.2695, 94.2968, 95.3071, 96.2844";

        nums = Array.ConvertAll(f.Split(','), float.Parse);
        foreach (float i in nums)
        {
            // x = i * speed + (speed * latency)
            Instantiate(thing,new Vector3(i * 5 + 1.5f,4,0),Quaternion.identity);
        }
        count = 1;
        nextHit = nums[count];

        TimerObj = GameObject.Find("Timer");
        HitterObj = GameObject.Find("Hitter");
        timerRenderer = TimerObj.GetComponent<Renderer>();
        hitterRenderer = HitterObj.GetComponent<Renderer>();

        timerMat = timerRenderer.material;
        hitterMat = hitterRenderer.material;
        hitterMat.EnableKeyword("_EMISSION");
        triggered = false;
    }
	
	// Update is called once per frame
	void Update () {
        bool playerHit = Input.GetKeyDown(KeyCode.W);

        Timer += Time.deltaTime;
        Color finalColor = Color.yellow * (1 - (Timer - nums[count - 1] / 1));

        timerMat.SetColor("_EmissionColor", finalColor);
        if (Timer > nextHit) {
            count++;
            nextHit = nums[count];
            lastHit = nums[count - 1];
            reset = lastHit + (nextHit - lastHit) / 2;

            if(!triggered)
                hitterMat.SetColor("_Color", Color.red);

            triggered = false;
        }

        if (Timer > reset) {
            triggered = false;
        }
        
        if (playerHit && Mathf.Abs(lastHit -Timer ) < latency)
        {
            Debug.Log("hit");
            hitterMat.SetColor("_Color", Color.blue);
            triggered = true;
        }
        else if (playerHit){
            hitterMat.SetColor("_Color", Color.red);
            triggered = false;
        }
	}
}
