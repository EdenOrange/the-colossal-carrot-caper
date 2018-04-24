using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GridPlayerController : MonoBehaviour {
    float timer = 0.15f;
    AudioSource song;
    bool started = false;
    PlayerState playerState;
    Vector3 destination;
    public BeatController bc;
    bool hasHit;

    // Use this for initialization
    void Start () {
        song = gameObject.GetComponent<AudioSource>();
        song.Play();
        playerState = GetComponent<PlayerState>();
        bc = GetComponent<BeatController>();
        destination = gameObject.transform.position;
    }

	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        float currentTime = ((timer ) % 0.6667f);
        bool moveable = currentTime < 0.13f || currentTime > 0.47f;

        if (currentTime <= 0.01f)
        {
            hasHit = false;
        }
        if (currentTime >= 0.65f && !hasHit && Time.timeSinceLevelLoad > 3)
        {
            bc.missBeat();
        }


        if (playerState.goal)
        {
            return;
        }

        bool w = Input.GetKeyDown(KeyCode.W);
        bool a = Input.GetKeyDown(KeyCode.A);
        bool s = Input.GetKeyDown(KeyCode.S);
        bool d = Input.GetKeyDown(KeyCode.D);

        
        Vector3 target = new Vector3(0,0,0);
        if ((w || a || s || d) && !moveable) {

            GameManager.beatsSinceHit++;
            AudioManager.Instance.PlaySfxMissedBeat();
            bc.missBeat();

        }
        if (w && moveable)
        {
            target = new Vector3(0, 0, 1) + target;

        }
        else if (s && moveable)
        {
            target = new Vector3(0, 0, -1) + target;

        }
        else if (a && moveable)
        {
            target = new Vector3(-1, 0, 0) + target;

        }
        
        else if (d && moveable)
        {
            target = new Vector3(1, 0, 0) + target;
            

        }

            RaycastHit hit;
        bool lookAhead = Physics.Raycast(transform.position, transform.TransformDirection(target), out hit, 1);


        // Does the ray intersect any objects excluding the player layer
        if (lookAhead && hit.transform.tag != "Wall")
        {
            bc.hitBeat();
            target += destination;
            destination = target;
            GameManager.beatsSinceHit = 0;
            started = true;
            hasHit = true;
        }
        else if (lookAhead && hit.transform.tag == "Wall")
        {
            Camera.main.GetComponent<CameraShake>().shakeDuration = 0.2f;
            //play wall hit sound
            // Destroy(hit.transform.gameObject);
        }


        if (transform.position != destination) {
            StartCoroutine(MoveWithLerp(destination));
        }
        if (!started) {
            GameManager.beatsSinceHit = 0;
        }


        if (GameManager.beatsSinceHit > 10) {
            started = false;
            GameManager.Instance.Lose();
        }
    }

    IEnumerator MoveWithLerp(Vector3 destination)
	{
		float progress = 0f;
		while (progress < 1f)
		{
			transform.position = Vector3.Lerp(transform.position, destination, progress);
			progress += Time.deltaTime * 10;
			yield return null;
		}
		transform.position = destination;
	}
}
