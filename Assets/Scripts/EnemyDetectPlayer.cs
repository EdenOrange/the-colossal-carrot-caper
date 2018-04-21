using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectPlayer : MonoBehaviour {

	public float distance;

	void Update()
	{
		int enemyLayer = 1 << LayerMask.NameToLayer("Enemy");
		int ignoreEnemyLayer = ~enemyLayer;

		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, ignoreEnemyLayer))
		{
			if (hit.transform.tag == "Player")
			{
				hit.transform.gameObject.GetComponent<GridPlayerController>().DetectedByEnemy();
			}
		}
	}
}
