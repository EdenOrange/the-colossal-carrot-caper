using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {

	public static AudioManager Instance { get; private set; }

	// public AudioClip bgm;
	public AudioClip sfxCarrotEat;
    public AudioClip sfxMissedBeat;

    // private AudioSource audioBgm;
    private AudioSource audioCarrotEat;
    private AudioSource audioMissedBeat;
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

		// audioBgm = AddAudio(bgm, true, false, 1f);
		audioCarrotEat = AddAudio(sfxCarrotEat, false, false, 1f);
        audioMissedBeat = AddAudio(sfxMissedBeat, false, false, 1f);
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
		PlayBGM();
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

	public void PlayBGM()
	{
		// audioBgm.Play();
		// LastBGM = audioBgm;
	}

	public void StopBGM()
	{
		if (LastBGM != null)
		{
			LastBGM.Stop();
		}
	}

	public void PlaySfxCarrotEat()
	{
		audioCarrotEat.Play();
	}
    public void PlaySfxMissedBeat()
    {
        audioMissedBeat.Play();
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
