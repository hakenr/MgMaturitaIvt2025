Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("Zadejte čísla vagónů v pořadí jejich příjezdu (oddělená mezerou):");
string input = Console.ReadLine();
var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
var vstupniVagony = new Queue<int>();
foreach (var token in tokens)
{
	vstupniVagony.Enqueue(int.Parse(token));
}

bool lzeSeradit = ZpracujStanici(vstupniVagony, out List<string> log);
Console.WriteLine(lzeSeradit ? "ANO" : "NE");
if (lzeSeradit)
{
	foreach (var krok in log)
	{
		Console.WriteLine(krok);
	}
}

static bool ZpracujStanici(Queue<int> vstup, out List<string> log)
{
	Stack<int> vedlejsi = new Stack<int>();
	int dalsiOcekavany = 1;
	log = new List<string>();

	while (vstup.Count > 0 || vedlejsi.Count > 0)
	{
		if (vstup.Count > 0 && vstup.Peek() == dalsiOcekavany)
		{
			int vagon = vstup.Dequeue();
			log.Add($"{vagon} projede po hlavní koleji");
			dalsiOcekavany++;
		}
		else if (vedlejsi.Count > 0 && vedlejsi.Peek() == dalsiOcekavany)
		{
			int vagon = vedlejsi.Pop();
			log.Add($"{vagon} zpět z vedlejší na hlavní kolej");
			dalsiOcekavany++;
		}
		else if (vstup.Count > 0)
		{
			int vagon = vstup.Dequeue();
			vedlejsi.Push(vagon);
			log.Add($"{vagon} na vedlejší kolej");
		}
		else
		{
			return false;
		}
	}

	return true;
}
