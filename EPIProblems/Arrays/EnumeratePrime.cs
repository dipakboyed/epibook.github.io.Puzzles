using System.Collections.Generic;

namespace EPI.Arrays
{
	/// <summary>
	/// Find all the prime numbers between 1 and a given number, N
	/// </summary>
	/// <remarks>We will use Sieve of Erastosthenes</remarks>
	public static class EnumeratePrime
	{
		public static List<int> GenerateAllPrimesFrom1toN(int n)
		{
			if (n < 1)
			{
				return null;
			}

			// index i in array will represent number i+1
			// initially default to false (false implies number is a prime, true implies the number is not a prime).
			bool[] sieve = new bool[n];

			// seed the result with 1
			List<int> primes = new List<int>();
			primes.Add(1);
			int currentNumber = 1;

			// traverse the sieve until the max number N
			while (currentNumber < n)
			{
				// iterate until we find the next prime number
				while(currentNumber < n && sieve[currentNumber])
				{
					currentNumber++;
				}

				if (currentNumber < n)
				{
					// add next prime number to return list
					sieve[currentNumber] = true;
					primes.Add(currentNumber + 1);

					// traverse the sieve and mark each multiple of i+1 as not a prime number
					int multiplesOfCurrentNumber = currentNumber;
					while (multiplesOfCurrentNumber < n)
					{
						if (!sieve[multiplesOfCurrentNumber])
						{
							sieve[multiplesOfCurrentNumber] = true;
						}
						multiplesOfCurrentNumber += currentNumber + 1;
					}
				}

				currentNumber++;
			}

			return primes;
		}
	}
}
