using var reader = new StreamReader(new FileInfo("Input.txt").OpenRead());
var commData = reader.ReadLine();

// const int windowSize = 4; // Part 1
const int windowSize = 14; // Part 2
for (var i = windowSize; i < commData?.Length; i++)
{
    if (commData[(i - windowSize)..i].GroupBy(c => c).Count() == windowSize)
    {
        Console.WriteLine(i);
        break;
    }
}