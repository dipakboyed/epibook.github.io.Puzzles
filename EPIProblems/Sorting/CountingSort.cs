using System.Collections.Generic;
using System.Linq;

namespace EPI.Sorting
{
	/// <summary>
	/// For arrays where the number of distinct elements is very low compared to the size, an efficient
	/// approach to sorting is the count the occurences of each distinct element and write them in sorted order.
	/// You are given an array of objects.Each object has a field that is to be treated as a key. Rearrange the
	/// elements of the array so that objects with equal keys appear together. the order in which distinct keys
	/// appear is not imporant
	/// </summary>
	public static class CountingSort
	{
		public class Element
		{
			public int key;
			public string name;

			public override int GetHashCode()
			{
				return key.GetHashCode();
			}

			public override bool Equals(object obj)
			{
				Element element = obj as Element;
				if (null != element)
				{
					return key.Equals(element.key) && name.Equals(element.name);
				}
				return false;
			}
		};

		public static void ReOrderArrayByElementKeys(Element[] array)
		{
			// first count the occurences of each key
			Dictionary<int, int> elementKeyCount = new Dictionary<int, int>();
			foreach (Element element in array)
			{
				if (!elementKeyCount.ContainsKey(element.key))
				{
					elementKeyCount.Add(element.key, 0);
				}
				elementKeyCount[element.key]++;
			}

			// We can optimize by reordering the array in-place
			// based on the occurence count, determine offset for each key subarray
			Dictionary<int, int> keyOffset = new Dictionary<int, int>();
			int offset = 0;
			foreach (int key in elementKeyCount.Keys)
			{
				keyOffset.Add(key, offset);
				offset += elementKeyCount[key];
			}

			// now perform in-place swap for each subarray based on it's offset
			while (keyOffset.Count > 0)
			{
				var fromKeyOffsetPair = keyOffset.First();
				var toOffsetKey = array[fromKeyOffsetPair.Value].key;

				// swap from and to
				Swap(array, fromKeyOffsetPair.Value, keyOffset[toOffsetKey]);

				// decrement key count
				--elementKeyCount[toOffsetKey];

				if (elementKeyCount[toOffsetKey] > 0)
				{
					// we still have more occurences of this key, increment offset
					++keyOffset[toOffsetKey];
				}
				else
				{
					// no more occurences of this key left to swapped, clean up
					keyOffset.Remove(toOffsetKey);
				}
			} // when all key offset subarray have been swapped
		}

		private static void Swap(Element[] array, int from, int to)
		{
			if (from != to)
			{
				var temp = array[from];
				array[from] = array[to];
				array[to] = temp;
			}
		}
	}
}
