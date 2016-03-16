using EPI.Arrays;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Arrays
{
	[TestClass]
	public class CelebrityMatchingUnitTest
	{
		[TestMethod]
		public void FindCelebrity()
		{
			var TwoPeopleFirstPersonIsCelebrity = new bool[,]
			{
				//			0	, 1
				/* 0 */ { false, false },
				/* 1 */ { true, false}
			};
			CelebrityMatching.FindTheCelebrity(TwoPeopleFirstPersonIsCelebrity).Should().Be(0);

			var TwoPeopleSecondPersonIsCelebrity = new bool[2,2] 
			{
				//			0	, 1
				/* 0 */ { false, true },
				/* 1 */ { false, false}
			};
			CelebrityMatching.FindTheCelebrity(TwoPeopleSecondPersonIsCelebrity).Should().Be(1);


			var ThreePeopleLastPersonIsCelebrity = new bool[,]
			{
				// set true for F[i,i] this time
				//			0 	, 1 	, 2
				/* 0 */ { true, false, true },
				/* 1 */ { true,  true, true },
				/* 2 */ { false, false, true }
			};
			CelebrityMatching.FindTheCelebrity(ThreePeopleLastPersonIsCelebrity).Should().Be(2);
		}
	}
}
