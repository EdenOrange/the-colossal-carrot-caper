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
			StartCoroutine(EnterWithDelay(1f));
		}
	}

	IEnumerator DelayedInteractable(float delay)
	{
		yield return new WaitForSeconds(delay);
		interactable = true;
	}

	IEnumerator EnterWithDelay(float delay)
	{
		UIController.Instance.FadeOut(delay);
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene("House");
	}
}
