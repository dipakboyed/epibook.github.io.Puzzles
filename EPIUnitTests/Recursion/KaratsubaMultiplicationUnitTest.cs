using EPI.Recursion;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.Recursion
{
	[TestClass]
	public class KaratsubaMultiplicationUnitTest
	{
		[TestMethod]
		public void KaratsubaMultiply()
        {
            KaratsubaMultiplication.Multiply("1234", "5678").Should().Be(7006652);
            KaratsubaMultiplication.Multiply("1234", "567").Should().Be(699678);;
            KaratsubaMultiplication.Multiply("123", "5678").Should().Be(698394);;
            KaratsubaMultiplication.Multiply("123", "567").Should().Be(69741);;

            KaratsubaMultiplication.Multiply("1234567", "56789").Should().Be(70109825363);;
        }
    }
}