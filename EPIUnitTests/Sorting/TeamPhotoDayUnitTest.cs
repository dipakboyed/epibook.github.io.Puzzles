using EPI.Sorting;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Sorting
{
	[TestClass]
	public class TeamPhotoDayUnitTest
	{
		[TestMethod]
		public void IsTeamPhotoPossible()
		{
			TeamPhotoDay.IsPhotoPlacementPossible(
				new int[] { 5,1,3,8,9,1,4,8,6,5,6},
				new int[] { 2,2,4,4,6,6,8,8,10,10,10}).Should().BeFalse();

			TeamPhotoDay.IsPhotoPlacementPossible(
				new int[] { 2, 1, 3, 11, 9, 10, 4, 8, 7, 5, 6 },
				new int[] { 3, 2, 4, 5, 7, 6, 9, 8, 11, 12, 10 }).Should().BeTrue();
		}
	}
}
