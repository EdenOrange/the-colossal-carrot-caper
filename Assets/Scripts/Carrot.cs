using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
	{
		if (collider.transform.tag == "Player")
		{
			PlayerState playerState = collider.transform.gameObject.GetComponent<PlayerState>();
			playerState.AddCarrot();
			if (AudioManager.Instance != null)
			{
				AudioManager.Instance.PlaySfxCarrotEat();
			}
			Destroy(gameObject);
		}
	}
}
