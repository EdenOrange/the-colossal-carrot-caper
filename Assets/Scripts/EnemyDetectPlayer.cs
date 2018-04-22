using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectPlayer : MonoBehaviour {

	public float distance;

	void Update()
	{
		int playerLayer = 1 << LayerMask.NameToLayer("Player");

		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, playerLayer))
		{
			if (hit.transform.tag == "Player")
			{
                gameObject.GetComponent<EnemyMovement>().detected = true;
			}
		}
	}
}
