using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseEnter : MonoBehaviour {

	private bool interactable;

	void Start()
	{
		interactable = false;
		StartCoroutine(DelayedInteractable(0.1f));
	}

	void OnTriggerEnter(Collider collider)
	{
		if (!interactable)
		{
			return;
		}

		if (collider.tag == "Player")
		{
			collider.GetComponent<PlayerController>().canAct = false;
			GameManager.Instance.LastTownPlayerPosition = collider.transform.position;
			Debug.Log("HouseEnter");
			SceneManager.LoadScene("House");
		}
	}

	IEnumerator DelayedInteractable(float delay)
	{
		yield return new WaitForSeconds(delay);
		interactable = true;
	}
}
