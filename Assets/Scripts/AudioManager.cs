using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

	public static AudioManager Instance { get; private set; }

	public AudioClip bgmMainMenu;
	public AudioClip bgmTown;
	public AudioClip bgmHouse;
	public AudioClip sfxDoorOpen;
	public AudioClip sfxDoorClose;
	
	private AudioSource audioMainMenu;
	private AudioSource audioTown;
	private AudioSource audioHouse;
	private AudioSource audioDoorOpen;
	private AudioSource audioDoorClose;

	public AudioSource LastBGM { get; private set; }

	private float defaultGlobalVolume = 0.7f;
	private float fadeTime = 1f;

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

		AudioListener.volume = defaultGlobalVolume;

		audioMainMenu = AddAudio(bgmMainMenu, true, false, 1f);
		audioTown = AddAudio(bgmTown, true, false, 1f);
		audioHouse = AddAudio(bgmHouse, true, false, 1f);
		audioDoorOpen = AddAudio(sfxDoorOpen, false, false, 1f);
		audioDoorClose = AddAudio(sfxDoorClose, false, false, 1f);
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
		StopBGM();
		switch (scene.name)
		{
			case "Main Menu": PlayBGMMainMenu(); break;
			case "Town": PlayBGMTown(); break;
			case "House": PlayBGMHouse(); break;
		}
	}

	AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float volume)
	{
		AudioSource newAudio = gameObject.AddComponent<AudioSource>();
		newAudio.clip = clip;
		newAudio.loop = loop;
		newAudio.playOnAwake = playAwake;
		newAudio.volume = volume;
		return newAudio;
	}

	public void PlayBGMMainMenu()
	{
		PlayFadeIn(audioMainMenu);
		LastBGM = audioMainMenu;
	}

	public void PlayBGMTown()
	{
		PlayFadeIn(audioTown);
		LastBGM = audioTown;
	}

	public void PlayBGMHouse()
	{
		PlayFadeIn(audioHouse);
		LastBGM = audioHouse;
	}

	public void StopBGM()
	{
		if (LastBGM != null)
		{
			LastBGM.Stop();
		}
	}

	public void PlaySfxDoorOpen()
	{
		audioDoorOpen.Play();
	}

	public void PlaySfxDoorClose()
	{
		audioDoorClose.Play();
	}

	public void PlayFadeIn(AudioSource audioSource)
	{
		StartCoroutine(FadeIn(audioSource));
	}

	public void PlayFadeOut(AudioSource audioSource)
	{
		StartCoroutine(FadeOut(audioSource));
	}

	IEnumerator FadeIn(AudioSource audioSource)
	{
		float volumeEnd = audioSource.volume;	
		audioSource.volume = 0f;
		
		audioSource.Play();
		while (audioSource.volume < volumeEnd)
		{
			audioSource.volume += volumeEnd * Time.deltaTime / fadeTime;
			yield return null;
		}
		audioSource.volume = volumeEnd;
	}

	IEnumerator FadeOut(AudioSource audioSource)
	{
		float volumeStart = audioSource.volume;

		while (audioSource.volume > 0f)
		{
			audioSource.volume -= volumeStart * Time.deltaTime / fadeTime;
			yield return null;
		}
		audioSource.Stop();
		audioSource.volume = volumeStart;
	}
}
