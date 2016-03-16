using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using EPI.Strings;
using FluentAssertions;

namespace EPI.UnitTests.Strings
{
	[TestClass]
	public class RomanNumeralsUnitTest
	{
		[TestMethod]
		public void ConvertToDecimal_Cases()
		{
			RomanNumerals.ConvertToDecimal("I").Should().Be(1);
			RomanNumerals.ConvertToDecimal("II").Should().Be(2);
			RomanNumerals.ConvertToDecimal("III").Should().Be(3);

			RomanNumerals.ConvertToDecimal("IV").Should().Be(4);
			RomanNumerals.ConvertToDecimal("IIII").Should().Be(4);

			RomanNumerals.ConvertToDecimal("V").Should().Be(5);
			RomanNumerals.ConvertToDecimal("VI").Should().Be(6);
			RomanNumerals.ConvertToDecimal("VII").Should().Be(7);
			RomanNumerals.ConvertToDecimal("VIII").Should().Be(8);
			
			RomanNumerals.ConvertToDecimal("VIIII").Should().Be(9);
			RomanNumerals.ConvertToDecimal("IX").Should().Be(9);

			RomanNumerals.ConvertToDecimal("X").Should().Be(10);

			RomanNumerals.ConvertToDecimal("XIIX").Should().Be(18);
			RomanNumerals.ConvertToDecimal("IIXX").Should().Be(18);
			RomanNumerals.ConvertToDecimal("XVIII").Should().Be(18);

			RomanNumerals.ConvertToDecimal("XL").Should().Be(40);
			RomanNumerals.ConvertToDecimal("L").Should().Be(50);

			RomanNumerals.ConvertToDecimal("XC").Should().Be(90);
			RomanNumerals.ConvertToDecimal("XCIX").Should().Be(99);
			RomanNumerals.ConvertToDecimal("C").Should().Be(100);

			RomanNumerals.ConvertToDecimal("CD").Should().Be(400);
			RomanNumerals.ConvertToDecimal("CDXC").Should().Be(490);
			RomanNumerals.ConvertToDecimal("CDXCIX").Should().Be(499);
			RomanNumerals.ConvertToDecimal("D").Should().Be(500);

			RomanNumerals.ConvertToDecimal("CM").Should().Be(900);
			RomanNumerals.ConvertToDecimal("CMXC").Should().Be(990);
			RomanNumerals.ConvertToDecimal("CMXCIX").Should().Be(999);
			RomanNumerals.ConvertToDecimal("M").Should().Be(1000);

			RomanNumerals.ConvertToDecimal("MCMX").Should().Be(1910);
			RomanNumerals.ConvertToDecimal("MDCCCCX").Should().Be(1910);
			RomanNumerals.ConvertToDecimal("CMMX").Should().Be(1910);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void ConvertToDecimal_InvalidCases()
		{
			RomanNumerals.ConvertToDecimal("IC");
		}
	}
}
