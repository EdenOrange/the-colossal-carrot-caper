using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenuController : MonoBehaviour {

	public static UIMainMenuController Instance { get; private set; }

	public GameObject mainMenu;
	public GameObject menuScreen;
	public GameObject optionsScreen;
	public GameObject creditsScreen;
	public string startButtonScene;

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

	void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (scene.name == "Main Menu")
		{
			mainMenu.SetActive(true);
		}
	}

	public void StartButton()
	{
		StartCoroutine(StartGame());
	}

	IEnumerator StartGame()
	{
		AudioManager.Instance.PlayFadeOut(AudioManager.Instance.LastBGM);
		UIFaderController.Instance.FadeOut(1f);
		yield return new WaitForSeconds(1f);
		mainMenu.SetActive(false);
		SceneManager.LoadScene(startButtonScene);
	}

	public void OptionsButton()
	{
		menuScreen.SetActive(false);
		optionsScreen.SetActive(true);
		creditsScreen.SetActive(false);
	}

	public void BackToMenuButton()
	{
		menuScreen.SetActive(true);
		optionsScreen.SetActive(false);
		creditsScreen.SetActive(false);
	}

	public void CreditsButton()
	{
		menuScreen.SetActive(false);
		optionsScreen.SetActive(false);
		creditsScreen.SetActive(true);
	}
}
