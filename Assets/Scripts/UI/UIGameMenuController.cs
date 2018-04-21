using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameMenuController : MonoBehaviour {

	public static UIGameMenuController Instance { get; private set; }

	public GameObject gameMenu;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameMenu.activeInHierarchy)
            {
                OpenGameMenu();
            }
            else
            {
                HideGameMenu();
            }
        }
    }

    void OpenGameMenu()
    {
        gameMenu.SetActive(true);
    }

    void HideGameMenu()
    {
        gameMenu.SetActive(false);
    }
}
