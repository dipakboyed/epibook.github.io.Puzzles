using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace EPI.Searching
{
	public static class SearchMissingIPAddress
	{
		/// <summary>
		/// Approaches:
		/// 1. Hash: Iterate the whole file and store all elements in a HashSet. Then increment from 0 and find 
		/// the missing entry not present in the hash. O(n) time but O(n) space. So doesnt meet the space constraints.
		/// 2. Sort: Iterate and can sort the file first, O(nlogn) time and then iterate again find the gap between consecutive elements. Typically
		/// this means sorted array will either be in memory (O(n) not good) or has to be saved to disk in chunks (which slows down time).
		/// 3. To meet the space constraints, iterate the fileStream multiple times.
		/// First pass, look at the 16 MSB (top 16 bits, top 2 IP tuples 255.255.x.x) of each address and store occurence count in an array.
		/// One of the array element's count will be less than 2^16. This narrows down our search for the next pass.
		/// Next pass only look at those IP addresses matching the 16 MSB of the item from the 1st pass and find the missing lower 16 bits.
		/// </summary>
		public static int FindMissingElement(Stream stream)
		{
			// Enumerate top 16 MSB of each IP and store counter in a bucket array
			int bucketSize = 1 << 16;
			int[] bucketMSB16 = Enumerable.Repeat<int>(0, bucketSize).ToArray();
			using (StreamReader reader = new StreamReader(stream))
			{
				while (!reader.EndOfStream)
				{
					uint current = Convert.ToUInt32(reader.ReadLine());
					uint currentMSB = current >> 16;
					bucketMSB16[currentMSB]++;
				}
			}

			// one of these buckets in the array must have count < 2^16 (bucketElementMaxCapacity)
			int bucketElementMaxCapacity = 1 << 16;
			int matchingBucket = 0;
			for (int i = 0; i < bucketMSB16.Length; i++)
			{
				if (bucketMSB16[i] < bucketElementMaxCapacity)
				{
					matchingBucket = i;
					break;
				}
			}

			// 2nd pass: enumerate lower 16 LSB of each IP matching the candidate_bucket's 16 MSB.
			BitArray bucketLSB16 = new BitArray(bucketSize, false);
			using (StreamReader reader = new StreamReader(stream))
			{
				while (!reader.EndOfStream)
				{
					uint current = Convert.ToUInt32(reader.ReadLine());
					uint currentMSB = current >> 16;
					if (matchingBucket == (int)currentMSB)
					{
						uint currentLSB = current & ((1 << 16) - 1);
						bucketLSB16[(int)currentLSB] = true;
					}
				}
			}

			// one of these buckets in the bit array must not have been set
			for (int i = 0; i < bucketLSB16.Length; i++)
			{
				if (!bucketLSB16[i] /* false */)
				{
					return (matchingBucket << 16) & i;
				}
			}

			throw new InvalidOperationException();
		}
	}
}
