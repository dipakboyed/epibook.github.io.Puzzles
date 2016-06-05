namespace EPI.Sorting
{
	/// <summary>
	/// Design an algorithm that takes as input two teams and the height of the players and checks if its
	/// possible to place players to take a photo subject to the placement constraint.
	/// The palcement constraint requires both teams to have the same number of players. All team members
	/// must be in the same row. And all players in the back row must be taller than the player in front of them.
	/// </summary>
	public static class TeamPhotoDay
	{
		public static bool IsPhotoPlacementPossible(int[] teamAPlayerHeights, int[] teamBPlayerHeights)
		{
			// sort each team's player height
			QuickSort<int>.Sort(teamAPlayerHeights);
			QuickSort<int>.Sort(teamBPlayerHeights);

			// let player at index 0 decide which team can be at front row
			bool isTeamAAtFrontRow = teamAPlayerHeights[0] < teamBPlayerHeights[0];
			for (int i = 0; i < teamAPlayerHeights.Length && i < teamBPlayerHeights.Length; i++)
			{
				if (isTeamAAtFrontRow)
				{
					if (teamAPlayerHeights[i] >= teamBPlayerHeights[i])
					{
						return false;
					}
				}
				else // team B is front row
				{
					if (teamBPlayerHeights[i] >= teamAPlayerHeights[i])
					{
						return false;
					}
				}
			}

			return true;
		}
	}
}
