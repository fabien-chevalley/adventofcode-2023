using System.Text.RegularExpressions;

namespace AdventOfCode.Year2023;

public class Day5 : ISolver<long>
{
    public long PartOne(string input)
    {
        var reader = new StringReader(input);
        var line = reader.ReadLine();
        var seeds = line.Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse);

        var mappers = GetMappers(reader);
        return MinLocation(mappers.ToArray(), seeds.ToArray());
    }

    public long PartTwo(string input)
    {
        var reader = new StringReader(input);
        var line = reader.ReadLine();
        var seedInput = line.Split(':')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(long.Parse)
            .ToArray();
        var seeds = new List<long>();

        for (var i = 0; i < seedInput.Length; i += 2)
        for (var ii = seedInput[i]; ii < seedInput[i] + seedInput[i + 1]; ii++)
            seeds.Add(ii);

        var mappers = GetMappers(reader);
        return MinLocation(mappers.ToArray(), seeds.ToArray());
    }

    private long MinLocation(Entry[][] mappers, long[] seeds)
    {
        var minLocation = long.MaxValue;
        foreach (var seed in seeds)
        {
            var value = seed;
            foreach (var entry in mappers)
            {
                var mappedValue = value;
                foreach (var e in entry)
                    if (value != e.Map(value))
                    {
                        mappedValue = e.Map(value);
                        break;
                    }

                value = mappedValue;
            }

            minLocation = Math.Min(minLocation, value);
        }

        return minLocation;
    }

    private List<Entry[]> GetMappers(StringReader reader)
    {
        var line = reader.ReadLine();
        var mappers = new List<Entry[]>();
        while (line != null)
        {
            if (line.Length == 0)
            {
                line = reader.ReadLine();
                line = reader.ReadLine();
            }

            var entries = new List<Entry>();
            Match match;
            while (line != null)
            {
                match = Regex.Match(line, @"(\d+) (\d+) (\d+)");
                if (!match.Success) break;

                entries.Add(new Entry(
                    long.Parse(match.Groups[1].Value),
                    long.Parse(match.Groups[2].Value),
                    long.Parse(match.Groups[3].Value)));

                line = reader.ReadLine();
            }

            mappers.Add(entries.ToArray());
        }

        return mappers;
    }

    private class Entry(long destination, long source, long length)
    {
        public long Map(long value)
        {
            if (value >= source && value < source + length) return destination + (value - source);

            return value;
        }
    }
}