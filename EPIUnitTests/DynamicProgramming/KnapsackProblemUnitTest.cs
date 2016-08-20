using EPI.DynamicProgramming;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.DynamicProgramming
{
	[TestClass]
	public class KnapsackProblemUnitTest
	{
		[TestMethod]
		public void TestMethod1()
		{
			KnapsackProblem.Clock[] store = new KnapsackProblem.Clock[]
			{
				new KnapsackProblem.Clock() { Price = 65,	Weight = 20 },
				new KnapsackProblem.Clock() { Price = 35,	Weight = 8 },
				new KnapsackProblem.Clock() { Price = 245,	Weight = 60 },
				new KnapsackProblem.Clock() { Price = 195,	Weight = 55 },
				new KnapsackProblem.Clock() { Price = 65,	Weight = 40 },
				new KnapsackProblem.Clock() { Price = 150,	Weight = 70 },
				new KnapsackProblem.Clock() { Price = 275,	Weight = 85 },
				new KnapsackProblem.Clock() { Price = 155,	Weight = 25 },
				new KnapsackProblem.Clock() { Price = 120,	Weight = 30 },
				new KnapsackProblem.Clock() { Price = 320,	Weight = 65 },
				new KnapsackProblem.Clock() { Price = 75,	Weight = 75 },
				new KnapsackProblem.Clock() { Price = 40,	Weight = 10 },
				new KnapsackProblem.Clock() { Price = 200,	Weight = 95 },
				new KnapsackProblem.Clock() { Price = 100,	Weight = 50 },
				new KnapsackProblem.Clock() { Price = 220,	Weight = 40 },
				new KnapsackProblem.Clock() { Price = 99,	Weight = 10 }
			};
			KnapsackProblem.Maximize(store, 130).Should().Be(695);
		}
	}
}
