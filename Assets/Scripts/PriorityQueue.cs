using System;
using System.Collections;
using System.Collections.Generic;

public class PriorityQueue<T> where T : IComparable<T> {
	private List<T> data;

	public PriorityQueue()
	{
		this.data = new List<T>();
	}

	public void Enqueue(T item)
	{
		data.Add(item);
		int childIdx = data.Count - 1;
		while (childIdx > 0)
		{
			int parentIdx = (childIdx - 1) / 2;
			if (data[childIdx].CompareTo(data[parentIdx]) >= 0)
			break;
			T tmp = data[childIdx]; data[childIdx] = data[parentIdx]; data[parentIdx] = tmp;
			childIdx = parentIdx;
		}
	}

	public T Dequeue()
	{
		// Assumes priority queue isn't empty
		int lastIdx = data.Count - 1;
		T frontItem = data[0];
		data[0] = data[lastIdx];
		data.RemoveAt(lastIdx);

		--lastIdx;
		int parentIdx = 0;
		while (true)
		{
			int childIdx = parentIdx * 2 + 1;
			if (childIdx > lastIdx) break;
			int rightChildIdx = childIdx + 1;
			if (rightChildIdx <= lastIdx && data[rightChildIdx].CompareTo(data[childIdx])  < 0)
			childIdx = rightChildIdx;
			if (data[parentIdx].CompareTo(data[childIdx]) <= 0) break;
			T tmp = data[parentIdx]; data[parentIdx] = data[childIdx]; data[childIdx] = tmp;
			parentIdx = childIdx;
		}
		return frontItem;
	}

	public int Count()
	{
		return data.Count;
	}
	
}
