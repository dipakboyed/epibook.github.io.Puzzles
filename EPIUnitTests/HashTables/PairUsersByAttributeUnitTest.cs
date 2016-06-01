using System;
using System.Collections.Generic;
using EPI.HashTables;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.HashTables
{
	[TestClass]
	public class PairUsersByAttributeUnitTest
	{
		[TestMethod]
		public void PairUsersWithSameAttributes()
		{
			PairUsersByAttribute pairUsers = new PairUsersByAttribute();
			pairUsers.AddUser(1, new List<string>() { "collegeGraduate" }).ShouldBeEquivalentTo(new Tuple<int, int>(-1, -1));
			pairUsers.AddUser(2, new List<string>() { "student" }).ShouldBeEquivalentTo(new Tuple<int, int>(-1, -1));
			pairUsers.AddUser(3, new List<string>() { "teacher", "history" }).ShouldBeEquivalentTo(new Tuple<int, int>(-1, -1));
			pairUsers.AddUser(4, new List<string>() { "history", "teacher" }).ShouldBeEquivalentTo(new Tuple<int, int>(4, 3));
			pairUsers.AddUser(5, new List<string>() { "student", "california" }).ShouldBeEquivalentTo(new Tuple<int, int>(-1, -1));
			pairUsers.AddUser(6, new List<string>() { "teacher", "history" }).ShouldBeEquivalentTo(new Tuple<int, int>(-1, -1));
			pairUsers.AddUser(7, new List<string>() { "collegeGraduate" }).ShouldBeEquivalentTo(new Tuple<int, int>(7, 1));

		}
	}
}
