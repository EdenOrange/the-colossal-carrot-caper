using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public List<Vector3> targetPoints;
	private int currentTargetIdx;

    public bool detected = false;
    public GameObject player;
	public float moveDelay = 0.66f;
	private float moveTimer;
    
	void Start()
	{
        player = GameObject.Find("Player");
        currentTargetIdx = 0;
		moveTimer = 0f;
        
	}

	void Update()
	{
		moveTimer += Time.deltaTime;
		if (moveTimer >= moveDelay)
		{
			Move();
			moveTimer -= moveDelay;
		}
	}

	void Move()
	{
		if (transform.position == targetPoints[currentTargetIdx])
		{
			currentTargetIdx = (currentTargetIdx + 1) % targetPoints.Count;
		}

        float targetX = targetPoints[currentTargetIdx].x;
        float targetZ = targetPoints[currentTargetIdx].z;

        if (detected) {
            targetX = player.transform.position.x;
            targetZ = player.transform.position.z;
        }

        /* Move towards next target point */
        
		float currentX = transform.position.x;
		float currentZ = transform.position.z;

        Vector3 target = new Vector3(0, 0, 0);
		if (currentX < targetX)
		{
            // Moves right
            target = new Vector3(1, 0, 0) + target;

            //transform.position = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
		}
		else if (currentX > targetX)
		{
            // Moves left
            target = new Vector3(-1, 0, 0) + target;
            //transform.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
		}
		else if (currentZ < targetZ)
		{
            // Moves up
            target = new Vector3(0, 0, 1) + target;
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
		}
		else if (currentZ > targetZ)
		{
            // Moves down
            target = new Vector3(0, 0, -1) + target;
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
		}
        RaycastHit hit;
        bool lookAhead = Physics.Raycast(transform.position, Vector3.forward, out hit, 0);
        print(lookAhead);

        // Does the ray intersect any objects excluding the player layer
        if (!lookAhead)
        {
            //print(hit);
            target += gameObject.transform.position;
            gameObject.transform.position = target;
        }
        if (lookAhead)
        {
            print(hit.transform.gameObject);
            //target += gameObject.transform.position;
            //gameObject.transform.position = target;
        }
        if (player.transform.position == transform.position) {
            GameManager.Instance.Lose();
        }

	}
}
