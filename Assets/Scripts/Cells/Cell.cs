public class Cell {
	public bool player;
	public bool enemy;
	public bool wall;
	public bool collectible;
	public bool goal;
	public bool ground;

	public Cell()
	{
		Init();
	}

	public void Init()
	{
		player = false;
		enemy = false;
		wall = false;
		collectible = false;
		goal = false;
		ground = false;
	}

	public override string ToString()
	{
		string cellContents = "";
		if (player) cellContents += "Player";
		if (enemy) cellContents += "Enemy";
		if (wall) cellContents += "Wall";
		if (collectible) cellContents += "Collectible";
		if (goal) cellContents += "Goal";
		if (ground) cellContents += "Ground";
		return cellContents;
	}
}
