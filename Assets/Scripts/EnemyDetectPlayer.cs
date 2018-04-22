using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectPlayer : MonoBehaviour {

	public float distance;

	void Update()
	{
		//int enemyLayer = 1 << LayerMask.NameToLayer("Enemy");
		//int ignoreEnemyLayer = ~enemyLayer;

		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance))
		{
			if (hit.transform.tag == "Player")
			{
                //
                gameObject.GetComponent<EnemyMovement>().detected = true;
                //hit.transform.gameObject.GetComponent<GridPlayerController>().DetectedByEnemy();
			}
		}
	}
}
