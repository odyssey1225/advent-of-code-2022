// See https://aka.ms/new-console-template for more information

var lowerCase = Enumerable.Range('a', 26);
var upperCase = Enumerable.Range('A', 26);
var packItems = lowerCase.Union(upperCase).Select(s => (char)s).ToList();

int PackItemPriority(char item) => packItems.IndexOf(item) + 1;

var elfPacks = new List<ElfPack>();
using (var reader = new StreamReader(new FileInfo("Input.txt").OpenRead()))
{
    while (!reader.EndOfStream)
    {
        var nextLine = reader.ReadLine();
        if (nextLine is null) continue;
        elfPacks.Add(new ElfPack(nextLine));
    }
}

var packItemScores = elfPacks.SelectMany(sm => sm.CommonItems).Select(PackItemPriority).Sum();

Console.WriteLine($"Part 1: {packItemScores}");

var badgeItemScores = 0;
for (var i = 0; i < elfPacks.Count; i += 3)
{
    var badgeItemTypes = elfPacks[i].ItemsInPack
        .Intersect(elfPacks[i + 1].ItemsInPack)
        .Intersect(elfPacks[i + 2].ItemsInPack);
    
    badgeItemScores += badgeItemTypes.Select(PackItemPriority).Sum();
}

Console.WriteLine($"Part 2: {badgeItemScores}");

public record ElfPack(string ItemsInPack)
{
    private int HalfOfItems => ItemsInPack.Length / 2;
    private string FirstCompartmentItems => ItemsInPack[..HalfOfItems];
    private string SecondCompartmentItems => ItemsInPack[HalfOfItems..];
    public IEnumerable<char> CommonItems => FirstCompartmentItems.Intersect(SecondCompartmentItems);
}
