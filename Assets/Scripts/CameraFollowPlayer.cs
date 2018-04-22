using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

	public GameObject player;
	public Vector3 offset = new Vector3(2,12,-8);


    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
	{
		transform.position = player.transform.position + offset;
	}
}
