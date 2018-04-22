using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

	public int carrots;
	public bool goal;

	void Start()
	{
		carrots = 0;
		goal = false;
	}

	public void GetCarrot()
	{
		carrots++;
	}
}
