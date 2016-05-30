using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPI.HashTables
{
	/// <summary>
	/// Write a function which takes as input a file and returns a pair of pages which have the highest affinity.
	/// Each line of the file/stream writes a page view consisting of the page id and user id separated by comma.
	/// The affinity of  a pair of pages is the number of distinct users who viewed both.
	/// </summary>
	/// <example>
	/// For log file:
	///		ayhoo, ap42
	///		oogleg, ap2
	///		tweeter, th1
	///		oogleg, aa314
	///		oogleg, aa314
	///		oogleg, th1
	///		tweeter, aa314
	///		tweeter, ap42
	///		ayhoo, aa314
	/// the affinity of {ayhoo, oogleg} is 1 since aa314 is the only distinct user who viewed both.
	/// The max affinity pair is {oogleg, tweeter} with value 2 for users th1 and aa314
	/// </example>
	public static class HighestAffinityPair
	{
		public static Tuple<string, string> FindHighestAffinityPair(Stream inputStream)
		{
			Dictionary<string, HashSet<string>> pageViewsToUsers = new Dictionary<string, HashSet<string>>();
			// read the input stream 
			using (StreamReader reader = new StreamReader(inputStream))
			{
				while (!reader.EndOfStream)
				{
					string line = reader.ReadLine();
					string[] pageAndUser = line.Split(',');
					if (pageAndUser.Length >= 2)
					{
						string pageId = pageAndUser[0];
						string userId = pageAndUser[1];
						if (!pageViewsToUsers.ContainsKey(pageId))
						{
							pageViewsToUsers.Add(pageId, new HashSet<string>());
						}
						if (!pageViewsToUsers[pageId].Contains(userId))
						{
							pageViewsToUsers[pageId].Add(userId);
						}
					}
				}
			}
			int maxAffinity = 0;
			Tuple<string, string> maxAffinityPair = new Tuple<string, string>(string.Empty, string.Empty);
			List<string> pageIds = pageViewsToUsers.Keys.ToList();
			for (int i = 0; i < pageIds.Count; i++)
			{
				for (int j = i + 1; j < pageIds.Count; j++)
				{
					var commonUser = pageViewsToUsers[pageIds[i]].Intersect(pageViewsToUsers[pageIds[j]]);
					int commonUserCount = commonUser.Count();
					if (commonUserCount > maxAffinity)
					{
						maxAffinity = commonUserCount;
						maxAffinityPair = new Tuple<string, string>(pageIds[i], pageIds[j]);
					}
				}
			}
			return maxAffinityPair;
		}
	}
}
