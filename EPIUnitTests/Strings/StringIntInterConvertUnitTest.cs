using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using EPI.Strings;

namespace EPI.UnitTests.Strings
{
	[TestClass]
	public class StringIntInterConvertUnitTest
	{
		[TestMethod]
		public void StringToInt()
		{
			Assert.AreEqual(0, StringIntInterConvert.StringToInt(""));
			Assert.AreEqual(-1, StringIntInterConvert.StringToInt("-1"));
			Assert.AreEqual(12340, StringIntInterConvert.StringToInt("12340"));
			Assert.AreEqual(-98765, StringIntInterConvert.StringToInt("-98765"));
			Assert.AreEqual(104, StringIntInterConvert.StringToInt("104"));
			Assert.AreEqual(104, StringIntInterConvert.StringToInt("0104"));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void StringToInt_InvalidNumber()
		{
			StringIntInterConvert.StringToInt("NotANumber");
		}

		[TestMethod]
		public void IntToString()
		{
			Assert.AreEqual("0", StringIntInterConvert.IntToString(0));
			Assert.AreEqual("-1", StringIntInterConvert.IntToString(-1));
			Assert.AreEqual("12340", StringIntInterConvert.IntToString(12340));
			Assert.AreEqual("-98765", StringIntInterConvert.IntToString(-98765));
			Assert.AreEqual("104", StringIntInterConvert.IntToString(104));
			Assert.AreEqual(Int32.MaxValue.ToString(), StringIntInterConvert.IntToString(Int32.MaxValue));
		}

		[TestMethod]
		[ExpectedException(typeof(OverflowException))]
		public void IntToString_Int32MinValue()
		{
			StringIntInterConvert.IntToString(Int32.MinValue);
		}
	}
}
