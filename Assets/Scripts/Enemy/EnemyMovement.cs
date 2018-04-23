using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public List<Vector3> targetPoints;
	private int currentTargetIdx;

    public bool detected = false;
    public GameObject player;
	public float moveDelay = 0.66f;
	private float moveTimer;

	private MapDataGenerator mapDataGenerator;
	private int[,] costMap; // The cost of a cell

	private PlayerState playerState;
	private EnemyState enemyState;

	/* Enemy's 4 materials representing Up, Down, Left, and Right */
	public Material enemyUp;
	public Material enemyDown;
	public Material enemyLeft;
	public Material enemyRight;
	private MeshRenderer meshRenderer;
    Vector3 destination;
    
	void Start()
	{
        player = GameObject.Find("Player");
        currentTargetIdx = 0;
		moveTimer = 0f;
        
		mapDataGenerator = GameObject.Find("MapManager").GetComponent<MapDataGenerator>();
		costMap = new int[MapDataGenerator.MAX_MAP_WIDTH, MapDataGenerator.MAX_MAP_LENGTH];
		playerState = GameObject.FindWithTag("Player").GetComponent<PlayerState>();
		enemyState = GetComponent<EnemyState>();
		enemyState.enemyFacing = EnemyState.EnemyFacing.UP;

		meshRenderer = transform.GetChild(0).GetComponent<MeshRenderer>();
	}

	void Update()
	{
		moveTimer += Time.deltaTime;
		if (moveTimer >= moveDelay && !playerState.goal)
		{
			Move();
			CatchPlayerCheck();
			moveTimer = 0;
		}
	}

	void Move()
	{
		if (transform.position == targetPoints[currentTargetIdx])
		{
			currentTargetIdx = (currentTargetIdx + 1) % targetPoints.Count;
		}

		Vector3 target;
		if (detected && player != null)
		{
			target = player.transform.position;
		}
		else
		{
			target = targetPoints[currentTargetIdx];
		}

        transform.position = NextMoveToTarget(target);

        //doesnt work.
        //destination = NextMoveToTarget(target);
        //if (transform.position != destination)
        //{
            
        //    transform.position = Vector3.Lerp(transform.position, destination, 16f * Time.deltaTime);
        //}
        
    }

	void CatchPlayerCheck()
	{
		if (player.transform.position == transform.position) {
			player.GetComponent<GridPlayerController>().CaughtByEnemy();
        }
	}

	/* Rotate according to move direction */
	void Rotate(Vector3 from, Vector3 to)
	{
		Vector3 direction = to - from;
		if (direction.x > 0f)
		{
			meshRenderer.material = enemyRight;
			enemyState.enemyFacing = EnemyState.EnemyFacing.RIGHT;
		}
		else if (direction.x < 0f)
		{
			meshRenderer.material = enemyLeft;
			enemyState.enemyFacing = EnemyState.EnemyFacing.LEFT;
		}
		else if (direction.z > 0f)
		{
			meshRenderer.material = enemyUp;
			enemyState.enemyFacing = EnemyState.EnemyFacing.UP;
		}
		else if (direction.z < 0f)
		{
			meshRenderer.material = enemyDown;
			enemyState.enemyFacing = EnemyState.EnemyFacing.DOWN;
		}
	}

	Vector3 NextMoveToTarget(Vector3 target)
	{
		// Debug.Log("Move to Target : " + target);
		/* Get a reference to the map cells data */
		Cell[,] cells = MapDataGenerator.cells;
		
		/* Calculate the cost of each cell */
		for (int i = 0; i < mapDataGenerator.mapWidth; i++)
		{
			for (int j = 0; j < mapDataGenerator.mapLength; j++)
			{
				if (cells[i, j].wall)
				{
					costMap[i, j] = 9999;
				}
				else 
				{
					costMap[i, j] = 1;
				}
			}
		}

		CellPosition targetPosition = new CellPosition((int)target.x, (int)target.z);
		CellPosition transformPosition = new CellPosition((int)transform.position.x, (int)transform.position.z);

		PriorityQueue<CellCost> frontier = new PriorityQueue<CellCost>();
		frontier.Enqueue(new CellCost(transformPosition, 0));
		Dictionary<CellPosition, CellPosition> cameFrom = new Dictionary<CellPosition, CellPosition>(new CellPosition.EqualityComparer());
		Dictionary<CellPosition, int> costSoFar = new Dictionary<CellPosition, int>(new CellPosition.EqualityComparer());
		cameFrom.Add(transformPosition, new CellPosition(-1, -1));
		costSoFar.Add(transformPosition, 0);

		/* A* algorithm */
		while (frontier.Count() > 0)
		{
			CellCost current = frontier.Dequeue();
			if (current.cellPosition.x == targetPosition.x && current.cellPosition.z == targetPosition.z) break;
			CellPosition[] possibleMoves = new CellPosition[4]
			{
				new CellPosition(1, 0),
				new CellPosition(-1, 0),
				new CellPosition(0, 1),
				new CellPosition(0, -1)
			};

			foreach (CellPosition move in possibleMoves)
			{
				int newCost = costSoFar[current.cellPosition] + costMap[current.cellPosition.z + move.z, current.cellPosition.x + move.x];
				CellPosition nextPosition = current.cellPosition + move;

				bool newCostIsCheaper = costSoFar.ContainsKey(nextPosition) ? newCost < costSoFar[nextPosition] : false;
				if (!costSoFar.ContainsKey(nextPosition) || newCostIsCheaper)
				{
					if (!costSoFar.ContainsKey(nextPosition)) costSoFar.Add(nextPosition, 0);
					costSoFar[nextPosition] = newCost;
					int priority = newCost + HeuristicCost(targetPosition, nextPosition);
					frontier.Enqueue(new CellCost(nextPosition, priority));
					if (!cameFrom.ContainsKey(nextPosition)) cameFrom.Add(nextPosition, new CellPosition(-1, -1));
					cameFrom[nextPosition] = current.cellPosition;
				}
			}
		}

		/* Get next position to move towards the target */
		CellPosition nextMovePosition = targetPosition;
		while (cameFrom[nextMovePosition].x != transformPosition.x || cameFrom[nextMovePosition].z != transformPosition.z)
		{
			nextMovePosition = cameFrom[nextMovePosition];
		}

		Vector3 nextMove = new Vector3(nextMovePosition.x, 0f, nextMovePosition.z);
		// Debug.Log("Decided next move : " + nextMove);
		Rotate(transform.position, nextMove);
		return nextMove;
	}

	/* Returns Manhattan distance from pointA to pointB */
	int HeuristicCost(CellPosition pointA, CellPosition pointB)
	{
		return (int)(Mathf.Abs(pointA.x - pointB.x) + Mathf.Abs(pointA.z - pointB.z));
	}
}