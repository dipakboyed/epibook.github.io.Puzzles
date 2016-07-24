using EPI.DynamicProgramming;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.DynamicProgramming
{
	[TestClass]
	public class BadNeighborUnitTest
	{
		[TestMethod]
		public void FindMaxDonationFromBadNeighbors()
		{
			BadNeighbors.FindMaxDonations(new[] { 10, 3, 2, 5, 7, 8 }).Should().Be(19);
			BadNeighbors.FindMaxDonations(new[] { 11, 15 }).Should().Be(15);
			BadNeighbors.FindMaxDonations(new[] { 7, 7, 7, 7, 7, 7, 7 }).Should().Be(21);
			BadNeighbors.FindMaxDonations(new[] { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 }).Should().Be(16);
			BadNeighbors.FindMaxDonations(new[]
			{
				94, 40, 49, 65, 21, 21, 106, 80, 92, 81, 679, 4, 61,
				6, 237, 12, 72, 74, 29, 95, 265, 35, 47, 1, 61, 397,
				52, 72, 37, 51, 1, 81, 45, 435, 7, 36, 57, 86, 81, 72
			}).Should().Be(2926);
		}
	}
}
