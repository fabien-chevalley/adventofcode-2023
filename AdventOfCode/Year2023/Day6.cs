namespace AdventOfCode.Year2023;

public class Day6 : ISolver<long>
{
    public long PartOne(string input)
    {
        var lines = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        var times = lines[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse)
            .ToArray();
        var distances = lines[1].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse)
            .ToArray();

        return times
            .Select((t, i) => new Race(t, distances[i]))
            .Select(r => r.NumberOfCandidate())
            .Aggregate((x, y) => x * y);
    }

    public long PartTwo(string input)
    {
        var lines = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        var times = lines[0].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse)
            .ToArray();
        var distances = lines[1].Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse)
            .ToArray();

        var race = new Race(long.Parse(string.Join("", times)), long.Parse(string.Join("", distances)));

        return race.NumberOfCandidate();
    }

    private class Race(long time, long distance)
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
}