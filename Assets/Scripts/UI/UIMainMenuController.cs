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
		SceneManager.LoadScene("Town");
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
