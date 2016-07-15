using System.Collections.Generic;

namespace EPI.HashTables
{
	/// <summary>
	/// Write a function that takes as input a string and a set of strings and returns the shortest prefix
	/// of the string which is not a prefix of any strings in the set
	/// </summary>
	/// <example>
	/// Query string "Cat", in dictionary {"dog", "be", "cut"}
	/// </example>
	public static class TrieShortestUniquePrefix
	{
		public static string FindShortestUniquePrefix(string query, HashSet<string> dictionary)
		{
			// Build a trie data structure from the dictionar
			Trie trie = new Trie();
			foreach (string word in dictionary)
			{
				trie.Insert(word);
			}

			return trie.GetShortestUniquePrefix(query);
		}

		private class Trie
		{
			private class TrieNode
			{
				// whether or not the current node char is the ending character of a valid word
				public bool isValidWord;
				// all possible child nodes from this node
				public Dictionary<char, TrieNode> children;

				public TrieNode()
				{
					isValidWord = false;
					children = new Dictionary<char, TrieNode>();
				}
			};

			private TrieNode root;

			public Trie()
			{
				root = new TrieNode(); // root doesn't correspond to any character
			}

			internal string GetShortestUniquePrefix(string query)
			{
				TrieNode node = root;
				string prefix = string.Empty;
				foreach (char character in query)
				{
					prefix += character;
					if (!node.children.ContainsKey(character))
					{
						return prefix;
					}
					else
					{
						node = node.children[character];
					}
				}

				//entire query string is present, shortest unique prefix not present is ""
				return string.Empty;
			}

			internal bool Insert(string word)
			{
				TrieNode node = root;
				// start from root and iterate all characters of the word
				// build child nodes for the isnerted word
				foreach (char character in word)
				{
					if (!node.children.ContainsKey(character))
					{
						node.children.Add(character, new TrieNode());
					}
					node = node.children[character];
				}

				if (node.isValidWord)
				{
					// word already exists in the trie
					// dont insert it again
					return false;
				}
				else
				{
					node.isValidWord = true;
					return true;
				}
			}
		}
	}
}
