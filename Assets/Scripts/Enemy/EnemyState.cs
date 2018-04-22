using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour {

	public enum EnemyFacing
	{
		UP,
		DOWN,
		LEFT,
		RIGHT
	}

	public EnemyFacing enemyFacing;
}
