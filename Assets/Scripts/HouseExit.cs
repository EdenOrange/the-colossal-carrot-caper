using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseExit : MonoBehaviour {

	public void ExitToTown()
	{
		SceneManager.LoadScene("Town");
	}
}
