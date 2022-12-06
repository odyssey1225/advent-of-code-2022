// See https://aka.ms/new-console-template for more information

var assignedSections = new List<Assignment>();

using var reader = new StreamReader(new FileInfo("Input.txt").OpenRead());
while (!reader.EndOfStream)
{
    var nextLine = reader.ReadLine();
    if (nextLine is null) continue;
    assignedSections.Add(new Assignment(nextLine.Split(',')));
}

Console.WriteLine($"Part 1: {assignedSections.Count(c => c.IsFullyContained)}");

Console.WriteLine($"Part 2: {assignedSections.Count(c => !c.HasNoOverlap)}");

public record Assignment(IEnumerable<string> AssignedSections)
{
    private int[] FirstSection => AssignedSections.First().Split('-').Select(int.Parse).ToArray();
    private int[] SecondSection => AssignedSections.Last().Split('-').Select(int.Parse).ToArray();

    public bool IsFullyContained =>
        (FirstSection[0] >= SecondSection[0] && FirstSection[1] <= SecondSection[1])
        || (SecondSection[0] >= FirstSection[0] && SecondSection[1] <= FirstSection[1]);

    public bool HasNoOverlap =>
        (FirstSection[0] < SecondSection[0] && FirstSection[1] < SecondSection[0])
        || (SecondSection[0] < FirstSection[0] && SecondSection[1] < FirstSection[0]);
}
