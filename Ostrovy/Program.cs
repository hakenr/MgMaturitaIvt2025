using Ostrovy;

public class Program
{
	public static void Main()
	{
		int[,] map = new int[,]
		{
			{ 1, 1, 0, 0, 0 },
			{ 1, 1, 0, 0, 1 },
			{ 0, 0, 0, 1, 1 },
			{ 0, 1, 0, 0, 1 }
		};

		IslandCounter counter = new IslandCounter();
		int result = counter.CountIslands(map);
		Console.WriteLine($"Počet ostrovů: {result}"); // Očekávaný výstup: 3
	}
}
