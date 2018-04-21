using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public static AudioManager Instance { get; private set; }

	public AudioClip sfxDoorOpen;
	private AudioSource audioDoorOpen;

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

	void Start()
	{
		audioDoorOpen = AddAudio(sfxDoorOpen, false, false, 0.5f);
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

	public void PlayDoorOpen()
	{
		audioDoorOpen.Play();
	}
}
