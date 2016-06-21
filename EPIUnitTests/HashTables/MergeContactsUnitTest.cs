using System.Collections.Generic;
using EPI.HashTables;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPI.UnitTests.HashTables
{
	[TestClass]
	public class MergeContactsUnitTest
	{
		[TestMethod]
		public void MergeContactsWithSameEmails()
		{
			List<MergeContacts.Contact> names = new List<MergeContacts.Contact>()
			{
				new MergeContacts.Contact() {Name = "Abby", Emails = new List<string>() { "a@a.com", "b@a.com"} },
				new MergeContacts.Contact() {Name = "Abbie", Emails = new List<string>() { "c@a.com", "b@a.com"} },
				new MergeContacts.Contact() {Name = "A.B.", Emails = new List<string>() { "c@a.com"} },
				new MergeContacts.Contact() {Name = "Bob", Emails = new List<string>() { "z@a.com"} }
			};

			MergeContacts.MergeContactNamesWithSameEmails(names).ShouldBeEquivalentTo(new List<List<string>>()
			{
				new List<string>() { "Abby", "Abbie", "A.B." },
				new List<string>() {"Bob" }
			}
			);
		}
	}
}
