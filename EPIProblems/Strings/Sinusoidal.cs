
namespace EPI.Strings
{
	/// <summary>
	/// A snake string is the left-right, top-bottom sequence in which
	/// characters appear when the string is written in sinusoidal fashion
	/// </summary>
	/// <example> snakestring of "Hello World!" is e lHloWrdlo!"</example>
	public static class Sinusoidal
	{
		public static string SnakeString(string sequence)
		{
			string result = "";
			// first row: s[1], s[5], s[9], ...
			for (int i = 1; i < sequence.Length; i += 4)
			{
				result += sequence[i];
			}

			// second row: s[0], s[2], s[4], s[6]. ...
			for (int i = 0; i < sequence.Length; i += 2)
			{
				result += sequence[i];
			}

			// third row: s[3], s[7], s[11], ...
			for (int i = 3; i < sequence.Length; i += 4)
			{
				result += sequence[i];
			}

			return result;
		}
	}
}
