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
			AudioManager.Instance.PlaySfxCarrotEat();
			Destroy(gameObject);
		}
	}
}
