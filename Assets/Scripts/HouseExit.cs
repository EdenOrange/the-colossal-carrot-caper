using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseExit : MonoBehaviour {

	public void ExitToTown()
	{
		StartCoroutine(DelayedExitToTown(1f));
	}

	IEnumerator DelayedExitToTown(float delay)
	{
		UIController.Instance.FadeOut(delay);
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene("Town");
	}
}
