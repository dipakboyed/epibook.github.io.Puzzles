using System;
using System.Collections.Generic;
using EPI.Arrays;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Arrays
{
	[TestClass]
	public class NonUniformRandomNumberGeneratorUnitTest
	{
		[TestMethod]
		public void GenerateNonUniformRandomNumber()
		{
			// seed the random generator in unit tests for deterministic results
			NonUniformRandomNumberGenerator.randomGenerator = new Random(42);
			int[] T = new int[] { 1, 2, 3, 4 };
			double[] P = new double[] { 0.1, 0.2, 0.3, 0.4 };

			List<int> actualResults = new List<int>();
			for (int i = 0; i < 15; i++)
			{
				actualResults.Add(NonUniformRandomNumberGenerator.GenerateNonUniformRandomNumber(T, P));
			}

			actualResults.ShouldBeEquivalentTo(new List<int>{ 4, 2, 2, 3, 2, 2, 4, 3, 2, 4, 2, 2, 3, 3, 3});
		}
	}
}
