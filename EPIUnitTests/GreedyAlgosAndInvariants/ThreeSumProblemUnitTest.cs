using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using EPI.GreedyAlgosAndInvariants;

namespace EPI.UnitTests.GreedyAlgosAndInvariants
{
    [TestClass]
	public class ThreeSumProblemUnitTest
	{
		[TestMethod]
		public void HasThreeSum()
		{
			Assert.IsTrue(ThreeSumProblem.HasThreeSum(new List<int> { 5, 2, 3, 4, 3 }, 9));
			Assert.IsFalse(ThreeSumProblem.HasThreeSum(new List<int> { 5, 2, 3, 4, 3 }, 4));
		}
	}
}
