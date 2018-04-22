using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Beat {
    public float time;
    public char key;
    public Beat(float time, char key) {
        this.time = time;
        this.key = key;
    }

}


public class RhythmTester : MonoBehaviour {
    float Timer = 0f;
   // float TimeDelay =  1f * 65/60;
    float nextHit = 0;
    float lastHit = 0.2f;
    float latency = 0.3f;
    float reset;
    AudioSource song;

    


    //bool hasHit = false;
    GameObject TimerObj;
    GameObject HitterObj;
    Image ScoreBar;
    Renderer timerRenderer;
    Renderer hitterRenderer;
    Material timerMat;
    Material hitterMat;
    GameObject thing;
    GameObject thingl;
    string[] keys;
    //string nextKey;
    string lastKey;
    float TimeSinceHit = 1;

    int count = 1;
    float[] nums;// = new List<float>();
    bool triggered;

    Text scoreDisplay;

    // Use this for initialization
    void Start () {
        song = gameObject.GetComponent<AudioSource>();
        scoreDisplay = GameObject.Find("ScoreDisplay").GetComponent<Text>();
        ScoreBar = GameObject.Find("ScoreBar").GetComponent<Image>();
        thing = GameObject.Find("RhythmBlock");
        thingl = GameObject.Find("RhythmBlockR");
        string times = "0, 0.4805, 1.0106, 1.3420, 2.2366, 3.0483, 3.4461, 4.3240, 5.0032, 5.4339, 6.1794, 6.9084, 7.3722, 8.1177, 8.8798, 9.3934, 10.1554, 10.9176, 11.3982, 12.1821, 12.9939, 13.3916, 14.1701, 15.0316, 15.4790, 16.1416, 16.7049, 17.1853, 17.6657, 18.2290, 18.7591, 19.2395, 19.7531, 20.2501, 20.6974, 21.1922, 21.7224, 22.2360, 22.7332, 23.2300, 23.7270, 24.2240, 24.7376, 25.2347, 25.7647, 26.2451, 26.7256, 27.2889, 27.8024, 28.2829, 28.7468, 29.2441, 29.7415, 30.2220, 30.7521, 31.2326, 31.7628, 32.2762, 32.7414, 33.2881, 33.7687, 34.2490, 34.7460, 35.2595, 35.7731, 36.2701, 36.7672, 37.2973, 37.7611, 38.2922, 38.7396, 39.1987, 39.7352";
        string keyString = "0, L,  R, R, L, R, R, L, R, R, L, R, R, L, R, R, L, R, R, L, R, R, L, R, R, L, L, R, R, L, L, R, R, L, L, R, R, L, L, R, R, L, L, L, L, R, R, R, R, L, L, L, L, R, R, R, R, L, R, L, R, L, R, L, R, L, L, R, R, L, R, L, R";
        nums = Array.ConvertAll(times.Split(','), float.Parse);
        keys = keyString.Split(',');
        for (int i = 0; i < nums.Length; i++)
        {
            if (keys[i].Trim().Equals("R"))
                Instantiate(thing, new Vector3(nums[i] * 5 + .75f, 3.5f, 0), Quaternion.identity);
            else
                Instantiate(thingl, new Vector3(nums[i] * 5 + .75f, 4.5f, 0), Quaternion.identity);


        }

        count = 1;
        nextHit = nums[count];
        triggered = false;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(count);
        //Debug.Log(nums);
        if (count + 1 < nums.Length)
        {
            TimeSinceHit += Time.deltaTime;
            bool leftHit = Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.LeftArrow);
            bool rightHit = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
            Timer += Time.deltaTime;

            if (Timer > nextHit)
            {
                count++;
                nextHit = nums[count];
                lastHit = nums[count - 1];


                //nextKey = keys[count].Trim();
                lastKey = keys[count-1].Trim();
                reset = lastHit + (nextHit - lastHit) / 2;

                triggered = false;
            }

            if (Timer > reset)
            {
                triggered = false;
            }

            if ((leftHit && lastKey.Equals("L") || rightHit && lastKey.Equals("R")) && Mathf.Abs(lastHit - Timer) < latency && !triggered)
            {
                triggered = true;
                ManagerGlobalVars.Energy += 0.5f;
                TimeSinceHit = 0;
            }
            else if (leftHit || rightHit)
            {
                triggered = false;
                ManagerGlobalVars.Energy -= 0.5f;
            }
            ManagerGlobalVars.Energy = Mathf.Clamp(ManagerGlobalVars.Energy, 0, 10);
            ManagerGlobalVars.Score += (int)(100 * ManagerGlobalVars.Energy * Time.deltaTime);
            ManagerGlobalVars.Energy -= 0.3f * Time.deltaTime;
            if (ManagerGlobalVars.Energy < 0.01)
            {
                ManagerGlobalVars.Energy = 0;
            }
            scoreDisplay.text = "Score: " + ManagerGlobalVars.Score + "\nEnergy: " + ManagerGlobalVars.Energy;

            ScoreBar.fillAmount = ManagerGlobalVars.Energy / 10;

            ManagerGlobalVars.TimeSinceHit = TimeSinceHit;


        }
        else if (song.volume > 0)
        {
            song.volume -= 0.01f;
        }
        else {
            if (Time.timeSinceLevelLoad > 50)
            {
                SceneManager.LoadScene("Town");
            }
        }
    }
}
