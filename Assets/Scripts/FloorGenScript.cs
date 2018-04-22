using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenScript : MonoBehaviour {
    public int width;
    public int depth;
    public Transform floorTile;
    public Transform FloorFolder;
    public Vector3 center = new Vector3(0, 0, 0);
	// Use this for initialization
	void Start () {
        for (int x = -(depth / 2) -1; x <= depth / 2 + 1; x++){
            for (int z = -(width / 2)-1; z <= width / 2 +1; z++)
            {
                Instantiate(floorTile, new Vector3(x, 0, z) + center, Quaternion.identity, FloorFolder);
            }
        }
	}

}
