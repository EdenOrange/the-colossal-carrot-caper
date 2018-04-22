using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectPlayer : MonoBehaviour {

	public float distance;

	private EnemyState enemyState;

	void Start()
	{
		enemyState = GetComponent<EnemyState>();
	}

	void Update()
	{
		int playerLayer = 1 << LayerMask.NameToLayer("Player");

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
		if (Physics.Raycast(transform.position, direction, out hit, distance, playerLayer))
		{
			if (hit.transform.tag == "Player")
			{
                gameObject.GetComponent<EnemyMovement>().detected = true;
			}
		}
	}
}
