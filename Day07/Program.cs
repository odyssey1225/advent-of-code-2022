
using var reader = new StreamReader(new FileInfo("SampleInput.txt").OpenRead());
while (!reader.EndOfStream)
{
    var nextLine = reader.ReadLine();
    if (nextLine is null) continue;
}