using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDataGenerator : MonoBehaviour {

	public const int MAX_MAP_LENGTH = 100;
	public const int MAX_MAP_WIDTH = 100;

	/* The cells data */
	public static Cell[,] cells;

	/* The coordinates for the most-bottom left of the level */
	public int xStart;
	public int zStart;

	public int mapLength;
	public int mapWidth;

	/* Position of the cell checker at Y-axis */
	private float checkerHeight = 0.5f;

	private Vector3 checkerSize = new Vector3(0.1f, 1f, 0.1f);

	void Start()
	{
		cells = new Cell[MAX_MAP_WIDTH, MAX_MAP_LENGTH];
		for (int i = 0; i < mapWidth; i++)
		{
			for (int j = 0; j < mapLength; j++)
			{
				cells[i, j] = new Cell();
			}
		}
	}

	void Update()
	{
		for (int currentZ = zStart; currentZ < zStart + mapWidth; currentZ++)
		{
			for (int currentX = xStart; currentX < xStart + mapLength; currentX++)
			{
				// Reset cell data before checking
				cells[currentZ, currentX].Init();

				// Do checks on the cell
				Vector3 currentPosition = new Vector3(currentX, checkerHeight, currentZ);
				Collider[] cellObjects = Physics.OverlapBox(currentPosition, checkerSize, Quaternion.identity);
				if (cellObjects.Length > 0)
				{
					foreach (Collider col in cellObjects)
					{
						switch (col.transform.tag)
						{
							case "Player":
								cells[currentZ, currentX].player = true;
								break;
							case "Enemy":
								cells[currentZ, currentX].enemy = true;
								break;
							case "Wall":
								cells[currentZ, currentX].wall = true;
								break;
							case "Collectible":
								cells[currentZ, currentX].collectible = true;
								break;
							case "Goal":
								cells[currentZ, currentX].goal = true;
								break;
							case "Ground":
								cells[currentZ, currentX].ground = true;
								break;	
						}
					}
				}
				// Debug.Log(currentPosition + " : " + cells[currentZ, currentX].ToString());
			}
		}
	}
}
