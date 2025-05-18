namespace Ostrovy;

public class IslandCounter
{
	public int CountIslands(int[,] map)
	{
		int rows = map.GetLength(0);
		int cols = map.GetLength(1);
		bool[,] visited = new bool[rows, cols];
		int islandCount = 0;

		// Projdi celou mřížku
		for (int row = 0; row < rows; row++)
		{
			for (int col = 0; col < cols; col++)
			{
				// Pokud je to země a ještě jsme ji nenavštívili, spustíme DFS
				if (map[row, col] == 1 && !visited[row, col])
				{
					DFS(map, visited, row, col);
					islandCount++; // každé nové DFS znamená nový ostrov
				}
			}
		}

		return islandCount;
	}

	// Pomocná metoda DFS - označí všechny buňky ostrova jako navštívené
	private void DFS(int[,] map, bool[,] visited, int row, int col)
	{
		int rows = map.GetLength(0);
		int cols = map.GetLength(1);

		// Pokud je mimo hranice nebo je to voda nebo už jsme navštívili, ukonči DFS
		if (row < 0 || col < 0 || row >= rows || col >= cols || map[row, col] == 0 || visited[row, col])
			return;

		visited[row, col] = true; // označ jako navštívené

		// Rekurzivní volání pro 4 směry (nahoru, dolů, vlevo, vpravo)
		DFS(map, visited, row - 1, col); // nahoru
		DFS(map, visited, row + 1, col); // dolů
		DFS(map, visited, row, col - 1); // vlevo
		DFS(map, visited, row, col + 1); // vpravo
	}
}
