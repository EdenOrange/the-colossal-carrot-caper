using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public List<Vector3> targetPoints;
	private int currentTargetIdx;

	public float moveDelay = 0.5f;
	private float moveTimer;

	void Start()
	{
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
		
		/* Move towards next target point */
		float targetX = targetPoints[currentTargetIdx].x;
		float targetZ = targetPoints[currentTargetIdx].z;
		float currentX = transform.position.x;
		float currentZ = transform.position.z;
		if (currentX < targetX)
		{
			// Moves right
			transform.position = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
			transform.rotation = Quaternion.Euler(0f, 90f, 0f);
		}
		else if (currentX > targetX)
		{
			// Moves left
			transform.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
			transform.rotation = Quaternion.Euler(0f, -90f, 0f);
		}
		else if (currentZ < targetZ)
		{
			// Moves up
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f);
			transform.rotation = Quaternion.Euler(0f, 0f, 0f);
		}
		else if (currentZ > targetZ)
		{
			// Moves down
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);
			transform.rotation = Quaternion.Euler(0f, 180f, 0f);
		}
	}
}
