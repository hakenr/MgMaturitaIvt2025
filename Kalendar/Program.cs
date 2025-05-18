using System.Globalization;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.Write("Zadejte rok a měsíc (např. 2024 5): ");
string[] input = Console.ReadLine().Split();
int year = int.Parse(input[0]);
int month = int.Parse(input[1]);

string[] dnyTydne = { "Po", "Út", "St", "Čt", "Pá", "So", "Ne" };
string mesicText = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
Console.WriteLine($"{char.ToUpper(mesicText[0]) + mesicText.Substring(1)} {year}");
Console.WriteLine(string.Join(" ", dnyTydne));

DateTime prvniDen = new DateTime(year, month, 1);
int dnuVMesici = DateTime.DaysInMonth(year, month);

// Převedení nedělního 0 na 7 pro zarovnání k pondělí (1)
int zacinameVTydnu = ((int)prvniDen.DayOfWeek == 0) ? 7 : (int)prvniDen.DayOfWeek;

int zarovnat = zacinameVTydnu - 1;
for (int i = 0; i < zarovnat; i++)
{
	Console.Write("   ");
}

for (int den = 1; den <= dnuVMesici; den++)
{
	Console.Write(den.ToString().PadLeft(2) + " ");
	if ((zarovnat + den) % 7 == 0)
	{
		Console.WriteLine();
	}
}
Console.WriteLine();
