using System;
using System.Collections.Generic;

namespace EPI.Graphs.Algorithms
{
    /// <summary>
	/// Basic class representing an object inside the minHeap 
    /// Contains the index of the graph node and the min distance (key) to that node
	/// </summary>
    public class MinHeapNode
    {
        public int dist;
        public int index;
        public MinHeapNode(int i, int d)
        {
            index = i;
            dist = d;
        }
    }

    /// <summary>
	/// Class representing a MinHeap with a DecreaseKey() method
	/// </summary>
    public class MinHeapWithDecreaseKey
    {
        public int size;
        MinHeapNode[] array;
        Dictionary<int, int> position; // key: graph node index, value: current position in array

        public MinHeapWithDecreaseKey(int capacity)
        {
            size = 0;
            array = new MinHeapNode[capacity];
            position = new Dictionary<int, int>();
        }

        public void Insert(int i, int edge)
        {
            if (size == array.Length)
            {
                throw new OutOfMemoryException();
            }
            array[size] = new MinHeapNode(i, edge);
            position[i] = size;
            HeapifyUp(size);
            size++;
        }

        public void DecreaseKey(int i, int newEdge)
        {
            int index = position[i];
            array[index].dist = newEdge;
            HeapifyUp(index);
        }

        private void HeapifyUp(int curr)
        {
            while (curr > 0)
            {
                int parent = (curr - 1)/2;
                if (array[parent].dist <= array[curr].dist)
                {
                    break;
                }
                Swap(curr, parent);
                curr = parent;
            }
        }

        public MinHeapNode Pop()
        {
            if (size == 0)
            {
                throw new ArgumentException();
            }
            
            var result = array[0];
            Swap(0, size-1);
            size--;
            HeapifyDown(0);
            position.Remove(result.index);
            return result;
        }

        private void HeapifyDown(int curr)
        {
           int smallest = curr;
           int left = (2* curr) + 1;
           int right = (2*curr) + 2;

           if (left < size && array[left].dist < array[smallest].dist)
           {
               smallest = left;
           }
           if ( right < size && array[right].dist < array[smallest].dist)
           {
               smallest = right;
           }

           if (smallest != curr)
           {
               Swap(curr, smallest);
               HeapifyDown(smallest);
           }
        }

        private void Swap(int curr, int parent)
        {
            var temp = array[curr];
            position[array[curr].index] = parent;
            position[array[parent].index] = curr;

            array[curr] = array[parent];
            array[parent] = temp;
        }
    }
}
