using System;

class Program
{
	static void Main()
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.Write("Zadejte kladné celé číslo: ");
		if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
		{
			int lowerPalindrome = GetLowerPalindrome(number);
			int higherPalindrome = GetHigherPalindrome(number);

			Console.WriteLine($"Nižší palindrom: {lowerPalindrome}");
			Console.WriteLine($"Vyšší palindrom: {higherPalindrome}");
		}
		else
		{
			Console.WriteLine("Neplatný vstup. Zadejte kladné celé číslo.");
		}
	}

	static int GetLowerPalindrome(int number)
	{
		string s = number.ToString();
		int len = s.Length;
		bool isOdd = len % 2 != 0;
		int halfLen = len / 2 + (isOdd ? 1 : 0);

		string firstHalf = s.Substring(0, halfLen);
		int firstHalfInt = int.Parse(firstHalf);

		while (true)
		{
			string candidate = Mirror(firstHalfInt.ToString(), isOdd);
			int candidateInt = int.Parse(candidate);

			if (candidateInt < number)
				return candidateInt;

			firstHalfInt--;
			if (firstHalfInt == 0)
				return 0; // special case for e.g. 1
		}
	}

	static int GetHigherPalindrome(int number)
	{
		string s = number.ToString();
		int len = s.Length;
		bool isOdd = len % 2 != 0;
		int halfLen = len / 2 + (isOdd ? 1 : 0);

		string firstHalf = s.Substring(0, halfLen);
		int firstHalfInt = int.Parse(firstHalf);

		while (true)
		{
			string candidate = Mirror(firstHalfInt.ToString(), isOdd);
			int candidateInt = int.Parse(candidate);

			if (candidateInt > number)
				return candidateInt;

			firstHalfInt++;
		}
	}

	static string Mirror(string firstHalf, bool isOdd)
	{
		char[] reversed = firstHalf.Substring(0, firstHalf.Length - (isOdd ? 1 : 0)).ToCharArray();
		Array.Reverse(reversed);
		return firstHalf + new string(reversed);
	}
}
