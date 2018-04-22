using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

	public int carrotsNeeded;
	public string nextLevelSceneName;

	void OnTriggerEnter(Collider collider)
	{
		if (collider.transform.tag == "Player")
		{
			PlayerState playerState = collider.transform.gameObject.GetComponent<PlayerState>();
			if (playerState.carrots >= carrotsNeeded)
			{
				playerState.goal = true;
				GameManager.Instance.Goal(nextLevelSceneName);
			}
		}
	}
}
