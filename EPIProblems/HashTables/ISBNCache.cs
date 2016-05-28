using System;
using System.Collections.Generic;

namespace EPI.HashTables
{
	/// <summary>
	/// Implement a cache for looking up prices of books identified by their ISBN number.
	/// You should support Lookup, Insert, Erase methods and use the least recently used (LRU)
	/// cache eviction policy
	/// </summary>
	public class ISBNCache
	{
		private const int cacheCapacity = 5;

		private Dictionary<int, Tuple<int, LinkedListNode<int>>> isbnTable;
		private LinkedList<int> lruCache;

		public ISBNCache()
		{
			isbnTable = new Dictionary<int, Tuple<int, LinkedListNode<int>>>();
			lruCache = new LinkedList<int>();
		}

		private void MoveItemToFrontOfLruCache(int itemISBN, LinkedListNode<int> cacheNode)
		{
			lruCache.Remove(cacheNode);
			lruCache.AddFirst(itemISBN);
		}

		public int Lookup(int isbn)
		{
			if (isbnTable.ContainsKey(isbn))
			{
				//already exists, move to front in LRU cache
				MoveItemToFrontOfLruCache(isbn, isbnTable[isbn].Item2);
				return isbnTable[isbn].Item1;
			}
			else
			{
				return -1;
			}
		}

		public void Insert(int isbn, int price)
		{
			if (isbnTable.ContainsKey(isbn))
			{
				//already exists, move to front in LRU cache
				MoveItemToFrontOfLruCache(isbn, isbnTable[isbn].Item2);
			}
			else
			{
				if (lruCache.Count == cacheCapacity)
				{
					// evict LRU item
					isbnTable.Remove(lruCache.Last.Value);
					lruCache.RemoveLast();
				}
				LinkedListNode<int> node = lruCache.AddFirst(isbn);
				isbnTable.Add(isbn, new Tuple<int, LinkedListNode<int>>(price, node));
			}
		}

		public bool Erase(int isbn)
		{
			if (isbnTable.ContainsKey(isbn))
			{
				lruCache.Remove(isbnTable[isbn].Item2);
				isbnTable.Remove(isbn);
				return true;
			}
			return false;
		}
	}
}
