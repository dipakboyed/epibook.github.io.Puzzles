namespace EPI.Arrays
{
	public static class CelebrityMatching
	{
		///<summary> Let F be an n x n boolean 2Darray representing the relationship between the people in a party
		/// F[a,b] is true if and only if a knows b.
		/// At a party everyone knows someone else.
		/// But there is one celebrity joining the party now - everyone knows him but he knows no one.
		/// Find the celebrity
		/// </summary>
		public static int FindTheCelebrity(bool[,] party)
		{
			// brute-force approach would be O(n^2) iterating through the entire 2D array
			// but we can do better by eliminating a candidate every time we look up an element from the array
			int i = 0;
			int j = 1;
			while (j < party.GetLength(1))
			{
				if (party[i,j])
				{
					// i knows j, so i cannot be the celebrity
					// move i = j' where for all j < j', party[i,j'] lookups have already been done
					i = j;
					j++;
				}
				else
				{
					//i doesn't know j, so j cannot be the celebrity
					// but i still might be the celebrity
					j++;
				}
			}

			return i;
		}
	}
}
