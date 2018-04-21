using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody playerRb;

	public float moveSpeed = 3f;
	private Vector3 movement;
	public bool canAct;

	void Start()
	{
		playerRb = GetComponent<Rigidbody>();
		canAct = true;

		// transform.position = GameManager.Instance.LastTownPlayerPosition;
	}

	void Update()
	{
		if (!canAct)
		{
			return;
		}

		float moveHorizontal;
		float moveVertical;

		moveHorizontal = Input.GetAxisRaw("Horizontal");
		moveVertical = Input.GetAxisRaw("Vertical");

		movement = new Vector3(moveHorizontal, 0, moveVertical);
		movement = transform.TransformDirection(movement.normalized);
		movement *= moveSpeed;
		playerRb.velocity = movement;
	}
}
