using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager Instance { get; private set; }

	/* Stores the player's position when moving out from town */
	public Vector3 LastTownPlayerPosition { get; set; }

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
		/* Set initial player position */
		LastTownPlayerPosition = new Vector3(0f, 1f, 0f);
	}
}
