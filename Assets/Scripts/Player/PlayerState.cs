using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

	public int carrots;
	public bool goal;
	public bool caught;

	void Start()
	{
		carrots = 0;
		goal = false;
		caught = false;
	}

	public void AddCarrot()
	{
		Debug.Log("Added carrot");
		carrots++;
	}

	public void Caught()
	{
		Debug.Log("Player caught");
		if (!caught)
		{
			GameManager.Instance.Lose();
			caught = true;
		}
	}
}
