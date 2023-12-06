Console.WriteLine("adventofcode - day 6");

var testInput = @"Time:      7  15   30
Distance:  9  40  200";

var input = @"Time:        56     97     77     93
Distance:   499   2210   1097   1440";

var lines = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

var times = lines[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
var distances = lines[1].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
var races = new List<Race>();
//for (var i = 0; i < times.Length; i++) races.Add(new Race(times[i], distances[i]));

races.Add(new Race(long.Parse(string.Join("", times)), long.Parse(string.Join("", distances))));

var results = races.Select(r => r.NumberOfCandidate());

Console.WriteLine($"result: {results.Aggregate((x, y) => x * y)}");

public class Race(long time, long distance)
{
    public int NumberOfCandidate()
    {
        var candidates = 0;
        for (var i = 1; i < time; i++)
            if (i * (time - i) > distance)
                candidates++;

        return candidates;
    }
}