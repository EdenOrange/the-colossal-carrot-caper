using System.Collections;
using System.Collections.Generic;

public class CellPosition {
	public int x;
	public int z;

	public CellPosition(int x, int z)
	{
		this.x = x;
		this.z = z;
	}

	public static CellPosition operator +(CellPosition cp1, CellPosition cp2)
	{
		return new CellPosition(cp1.x + cp2.x, cp1.z + cp2.z);
	}

	public class EqualityComparer : IEqualityComparer<CellPosition> {
		public bool Equals(CellPosition cp1, CellPosition cp2)
		{
			return cp1.x == cp2.x && cp1.z == cp2.z;
		}

		public int GetHashCode(CellPosition cellPosition)
		{
			return cellPosition.x ^ cellPosition.z;
		}
	}
}