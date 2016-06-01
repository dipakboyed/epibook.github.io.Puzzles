using System;
using System.Collections.Generic;

namespace EPI.HashTables
{
	/// <summary>
	/// You are given a sequence of users where each user has a unique 32-bit int key (userId) and
	/// a set of attributes specified as strings.
	/// When you read a user, you should pair that user with another previously read user with identical
	/// attributes who is currently unpaired, if such a piar exists.
	/// if the user cannot be paired, you should add him to the unpaired list
	/// </summary>
	public class PairUsersByAttribute
	{
		// maintain a hashtable where key is the set of attributes and value is a list of unpaired userIds containing those attributes.
		// the attributes key can be composed many ways:
		// 1. maintain a bit array where each bit represents a specific attribute (1 means user contains that attribute, 0 means does not).
		// But this requires a static list of attributes and is also limited by the number of bits.
		// 2. sort the attributes (ignore casing) and append all user's attributes to build a key. This handles a dynamic list of attributes
		private Dictionary<string, Queue<int>> unpairedUsersByAttribute;

		public PairUsersByAttribute()
		{
			unpairedUsersByAttribute = new Dictionary<string, Queue<int>>();
		}

		public Tuple<int, int> AddUser(int userId, List<string> userAttributes)
		{
			string hashKey = string.Empty;
			userAttributes.Sort();
			foreach (string attribute in userAttributes)
			{
				hashKey += attribute + ",";
			}

			if (unpairedUsersByAttribute.ContainsKey(hashKey))
			{
				if (unpairedUsersByAttribute[hashKey].Count > 0)
				{
					return new Tuple<int, int>(userId, unpairedUsersByAttribute[hashKey].Dequeue());
				}
			}
			else
			{
				unpairedUsersByAttribute.Add(hashKey, new Queue<int>());
			}
			unpairedUsersByAttribute[hashKey].Enqueue(userId);
			return new Tuple<int, int>(-1, -1); //not paired
		}
	}
}
