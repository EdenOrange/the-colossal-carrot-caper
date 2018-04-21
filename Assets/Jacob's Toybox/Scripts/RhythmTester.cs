using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RhythmTester : MonoBehaviour {
    float Timer = 0f;
    float TimeDelay =  1f * 65/60;
    float nextHit = 0;
    float lastHit = 0.2f;
    float latency = 0.3f;
    float reset;
    AudioSource song;

    int score = 0;
    


    bool hasHit = false;
    GameObject TimerObj;
    GameObject HitterObj;
    Image ScoreBar;
    Renderer timerRenderer;
    Renderer hitterRenderer;
    Material timerMat;
    Material hitterMat;
    GameObject thing;


    float TimeSinceHit = 1;

    int count;
    float[] nums;
    bool triggered;

    Text scoreDisplay;

    // Use this for initialization
    void Start () {
        song = gameObject.GetComponent<AudioSource>();
        scoreDisplay = GameObject.Find("ScoreDisplay").GetComponent<Text>();
        ScoreBar = GameObject.Find("ScoreBar").GetComponent<Image>();
        GameObject thing = GameObject.Find("RhythmBlock");
        string f = "0, 0.5446, 1.0087, 1.4226, 2.1681, 2.8639, 3.3113, 4.2058, 4.8188, 5.3158, 6.1441, 6.9063, 7.3702, 8.1489, 8.8610, 9.3083, 10.1035, 10.8823, 11.2963, 12.0918, 12.9198, 13.3673, 14.2120, 14.9741, 15.4214, 16.1505, 16.8959, 17.3763, 18.2214, 18.9170, 19.3809, 20.1926, 20.6400, 21.1369, 21.7003, 22.2138, 22.7273, 23.1912, 23.7213, 24.2367, 24.7505, 25.2306, 25.7111, 26.2081, 26.6719, 27.2021, 27.7157, 28.2126, 28.7096, 29.2895, 29.7368, 30.2503, 30.7473, 31.2112, 31.7248, 32.2715, 32.7188, 33.2489, 33.7294, 34.2429, 34.7234, 35.1873, 35.7174, 36.2475, 36.7114, 37.2084, 37.6891, 38.1858, 38.6663, 39.2131, 39.7104, 40.1904, 40.6377, 41.1182, 41.6152, 42.1619, 42.6755, 43.1725, 43.6418, 44.2048, 44.7018, 45.1659, 45.6627, 46.1929, 46.7229, 47.1702, 47.6343, 48.1808, 48.6944, 49.1748, 49.7549";

        nums = Array.ConvertAll(f.Split(','), float.Parse);
        foreach (float i in nums)
        {
            // x = i * speed + (speed * latency / 2)
            Instantiate(thing,new Vector3(i * 5 + .75f,4,0),Quaternion.identity);
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
        if (count + 1 < nums.Length)
        {
            TimeSinceHit += Time.deltaTime;
            bool playerHit = Input.GetKeyDown(KeyCode.W);

            Timer += Time.deltaTime;
            Color finalColor = Color.yellow * (1 - (Timer - nums[count - 1] / 1));

            timerMat.SetColor("_EmissionColor", finalColor);
            if (Timer > nextHit)
            {
                count++;
                nextHit = nums[count];
                lastHit = nums[count - 1];
                reset = lastHit + (nextHit - lastHit) / 2;

                if (!triggered)
                    hitterMat.SetColor("_Color", Color.red);

                triggered = false;
            }

            if (Timer > reset)
            {
                triggered = false;
            }

            if (playerHit && Mathf.Abs(lastHit - Timer) < latency && !triggered)
            {
                Debug.Log("hit");
                hitterMat.SetColor("_Color", Color.blue);
                triggered = true;
                ManagerGlobalVars.Energy += 0.5f;
                TimeSinceHit = 0;
            }
            else if (playerHit)
            {
                hitterMat.SetColor("_Color", Color.red);
                triggered = false;
                ManagerGlobalVars.Energy -= 0.5f;
            }
            ManagerGlobalVars.Energy = Mathf.Clamp(ManagerGlobalVars.Energy, 0, 10);
            score += (int)(100 * ManagerGlobalVars.Energy * Time.deltaTime);
            ManagerGlobalVars.Energy -= 0.3f * Time.deltaTime;
            if (ManagerGlobalVars.Energy < 0.01)
            {
                ManagerGlobalVars.Energy = 0;
            }
            scoreDisplay.text = "Score: " + score + "\nEnergy: " + ManagerGlobalVars.Energy;

            ScoreBar.fillAmount = ManagerGlobalVars.Energy / 10;

            ManagerGlobalVars.TimeSinceHit = TimeSinceHit;


        }
        else if (song.volume > 0)
        {
            song.volume -= 0.01f;
        }
        else {
            if (Time.time > 60)
            {
                SceneManager.LoadScene("Town");
            }
        }
    }
}
