using System.Collections.Generic;
using System.Linq;

namespace EPI.HashTables
{
	/// <summary>
	/// You are given a list of contacts (containing name and one or more emails) from various sources
	/// and you need to join all contacts with the same emails and return distinct sets of names
	/// </summary>
	/// <example>
	/// {Angela - a @fb.com, b @fb.com}
	/// {Angie - b @fb.com, c @fb.com}
	/// {A. L. - c @fb.com}
	/// {Bob   - z @fb.com}
	/// returns:
	/// [Angela, Angie, A.L.], [Bob]
	/// </example>
	public static class MergeContacts
	{

		private class MergedContacts
		{
			public HashSet<string> Names = new HashSet<string>();
			public HashSet<string> Emails = new HashSet<string>();
		};

		public class Contact
		{
			public string Name;
			public List<string> Emails = new List<string>();
		};

		public static List<List<string>> MergeContactNamesWithSameEmails(List<Contact> contacts)
		{
			List<MergedContacts> distinctContacts = new List<MergedContacts>();
			Dictionary<string, int> emailToListIndex = new Dictionary<string, int>();

			foreach (var contact in contacts)
			{
				int emailExistsIndex = -1;
				foreach (string email in contact.Emails)
				{
					if (emailToListIndex.ContainsKey(email))
					{
						emailExistsIndex = emailToListIndex[email];
						break;
					}
				}

				if (emailExistsIndex >= 0)
				{
					if (!distinctContacts[emailExistsIndex].Names.Contains(contact.Name))
					{
						distinctContacts[emailExistsIndex].Names.Add(contact.Name);
					}
					foreach (var email in contact.Emails)
					{
						if (!distinctContacts[emailExistsIndex].Emails.Contains(email))
						{
							distinctContacts[emailExistsIndex].Emails.Add(email);
							emailToListIndex.Add(email, emailExistsIndex);
						}
					}
				}
				else
				{
					MergedContacts c = new MergedContacts();
					c.Names.Add(contact.Name);
					foreach (var email in contact.Emails)
					{
						c.Emails.Add(email);
						emailToListIndex.Add(email, distinctContacts.Count);
					}
					distinctContacts.Add(c);
				}
			}

			List<List<string>> result = new List<List<string>>();
			foreach (var distinctContact in distinctContacts)
			{
				result.Add(distinctContact.Names.ToList());
			}
			return result;
		}
	}
}
