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
        Vector3 targetpos = player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetpos, 1.0f * Time.deltaTime);
        
	}
}
