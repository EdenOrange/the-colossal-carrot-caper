using System;
using System.Collections;
using System.Collections.Generic;

public struct CellCost : IComparable<CellCost> {
	public CellPosition cellPosition;
	public int cellCost;

	public CellCost(CellPosition cellPosition, int cellCost)
	{
		this.cellPosition = cellPosition;
		this.cellCost = cellCost;
	}

	public int CompareTo(CellCost other)
	{
		if (this.cellCost < other.cellCost) return -1;
		else if (this.cellCost > other.cellCost) return 1;
		else return 0;
	}
}