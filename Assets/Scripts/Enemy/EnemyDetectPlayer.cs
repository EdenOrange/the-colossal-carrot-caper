using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectPlayer : MonoBehaviour {

	public float distance;

	private PlayerState playerState;
	private EnemyState enemyState;

	private int playerLayer;
	private int wallsLayer;
	private int layerToDetect;

	void Start()
	{
		playerState = GameObject.Find("Player").GetComponent<PlayerState>();
		enemyState = GetComponent<EnemyState>();

		playerLayer = 1 << LayerMask.NameToLayer("Player");
		wallsLayer = 1 << LayerMask.NameToLayer("Walls");
		layerToDetect = playerLayer | wallsLayer;
	}

	void Update()
	{
		Vector3 direction = new Vector3(0f, 0f, 0f);
		switch (enemyState.enemyFacing)
		{
			case EnemyState.EnemyFacing.UP:
				direction = new Vector3(0f, 0f, 1f);
				break;
			case EnemyState.EnemyFacing.DOWN:
				direction = new Vector3(0f, 0f, -1f);
				break;
			case EnemyState.EnemyFacing.LEFT:
				direction = new Vector3(-1f, 0f, 0f);
				break;
			case EnemyState.EnemyFacing.RIGHT:
				direction = new Vector3(1f, 0f, 0f);
				break;
		}

		RaycastHit hit;
		if (Physics.Raycast(transform.position, direction, out hit, distance, layerToDetect))
		{
			if (hit.transform.tag == "Player")
			{
				if (!playerState.caught)
				{
					gameObject.GetComponent<EnemyMovement>().detected = true;
				}
			}
		}
	}
}
