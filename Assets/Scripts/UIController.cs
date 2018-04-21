using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public static UIController Instance { get; private set; }

	public GameObject screenFader;

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
		screenFader.SetActive(true);
	}

	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		FadeIn(1f);
	}

	public void FadeOut(float duration)
	{
		StartCoroutine(Fade(0f, 1f, duration));
	}

	public void FadeIn(float duration)
	{
		StartCoroutine(Fade(1f, 0f, duration));
	}

	IEnumerator Fade(float fadeAlphaFrom, float fadeAlphaTo, float duration)
	{
		Image screenFaderImage = screenFader.GetComponent<Image>();
		for (float t = 0f; t < 1f; t += Time.deltaTime / duration)
		{
			Color newColor = new Color(screenFaderImage.color.r, screenFaderImage.color.g, screenFaderImage.color.b, Mathf.Lerp(fadeAlphaFrom, fadeAlphaTo, t));
			screenFader.GetComponent<Image>().color = newColor;
			yield return null;
		}
	}
}
