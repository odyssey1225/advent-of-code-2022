// See https://aka.ms/new-console-template for more information

var file = new FileInfo("Input.txt");

var elfRations = new List<ElfRation>();

using (var reader = new StreamReader(file.OpenRead()))
{
    while (!reader.EndOfStream)
    {
        var elfRation = new ElfRation();
        var nextLine = reader.ReadLine();
        
        while (nextLine?.Length > 0)
        {
            if (int.TryParse(nextLine, out var calories))
            {
                elfRation.Rations.Add(calories);
            }

            nextLine = reader.ReadLine();
        }

        elfRations.Add(elfRation);
    }
}

var maxCalories = elfRations.Max(m => m.TotalCalories);
Console.WriteLine(maxCalories);

var topThreeCalories = elfRations.OrderByDescending(o => o.TotalCalories).Take(3).Sum(s => s.TotalCalories);
Console.WriteLine(topThreeCalories);

public record ElfRation
{
    public List<int> Rations { get; } = new();
    public int TotalCalories => Rations.Sum();
}