// See https://aka.ms/new-console-template for more information

// Value index map: 0 = win, 1 = draw, 2 = lose
var winningThrows = new Dictionary<char, string>
{
    { 'A', "YXZ" },
    { 'B', "ZYX" },
    { 'C', "XZY" }
};

int ScoreThrow(char mine)
{
    return mine switch
    {
        'X' => 1,
        'Y' => 2,
        'Z' => 3,
        _ => 0
    };
}

int ScoreRound(char theirs, char mine)
{
    var throwScore = ScoreThrow(mine);
    var roundScore = winningThrows[theirs][0] == mine ? 6 : winningThrows[theirs][1] == mine ? 3 : 0;
    return throwScore + roundScore;
}

int CheatRound(char theirs, char outcome)
{
    return outcome switch
    {
        'X' => ScoreRound(theirs, winningThrows[theirs][2]), // Lose
        'Y' => ScoreRound(theirs, winningThrows[theirs][1]), // Draw
        'Z' => ScoreRound(theirs, winningThrows[theirs][0]), // Win
        _ => 0
    };
}

var score = 0;
var cheatScore = 0;
var file = new FileInfo("Input.txt");

using (var reader = new StreamReader(file.OpenRead()))
{
    while (!reader.EndOfStream)
    {
        var round = reader.ReadLine();
        if (round is null || round.Length < 3) continue;
        score += ScoreRound(round[0], round[2]);
        cheatScore += CheatRound(round[0], round[2]);
    }
}

Console.WriteLine($"Part 1: {score}");
Console.WriteLine($"Part 2: {cheatScore}");
