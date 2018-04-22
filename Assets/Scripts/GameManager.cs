using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager Instance { get; private set; }

	void Awake()
	{
		if (Instance == null)
		{
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}

	public void Goal(string nextLevelSceneName)
	{
		UIFaderController.Instance.FadeOut(1f);
		StartCoroutine(LoadLevelWithDelay(nextLevelSceneName, 1f));
	}

	public void Lose()
	{
		UIFaderController.Instance.FadeOut(1f);
		StartCoroutine(LoadLevelWithDelay(SceneManager.GetActiveScene().name ,1f));
	}

	IEnumerator LoadLevelWithDelay(string sceneName, float delay)
	{
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene(sceneName);
	}
}
