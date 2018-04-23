using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

	public void ChooseLevel(string sceneName)
	{
		StartCoroutine(ChooseLevelExecute(sceneName));
	}

	IEnumerator ChooseLevelExecute(string sceneName)
	{
		AudioManager.Instance.PlayFadeOut(AudioManager.Instance.LastBGM);
		UIFaderController.Instance.FadeOut(1f);
		yield return new WaitForSeconds(1f);
		StartCoroutine(LoadLevelWithDelay(sceneName, 1f));
	}

	IEnumerator LoadLevelWithDelay(string sceneName, float delay)
	{
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene(sceneName);
	}
}
