using System.Text.RegularExpressions;

namespace AdventOfCode.Year2023;

public class Day2 : ISolver<int>
{
    public int PartOne(string input)
    {
        var sum = 0;
        var reader = new StringReader(input);
        var line = reader.ReadLine();
        while (line != null)
        {
            var gameId = int.Parse(Regex.Match(line, @"Game (\d+)").Groups[1].Value);

            var isValid = TryParseValues(line, out _, out _, out _);
            if (isValid) sum += gameId;

            line = reader.ReadLine();
        }

        return sum;
    }

    public int PartTwo(string input)
    {
        var power = 0;
        var reader = new StringReader(input);
        var line = reader.ReadLine();
        while (line != null)
        {
            TryParseValues(line, out var maxGreen, out var maxRed, out var maxBlue);

            power += maxBlue * maxRed * maxGreen;

            line = reader.ReadLine();
        }

        return power;
    }

    private static bool TryParseValues(string line, out int maxGreen, out int maxRed, out int maxBlue)
    {
        maxRed = 0;
        maxGreen = 0;
        maxBlue = 0;

        var sections = line.Split(";");
        var valid = true;
        foreach (var section in sections)
        {
            int.TryParse(Regex.Match(section, @"(\d+) blue").Groups[1].Value, out var blue);
            int.TryParse(Regex.Match(section, @"(\d+) red").Groups[1].Value, out var red);
            int.TryParse(Regex.Match(section, @"(\d+) green").Groups[1].Value, out var green);

            valid &= blue <= 14 && red <= 12 && green <= 13;

            maxBlue = Math.Max(blue, maxBlue);
            maxGreen = Math.Max(green, maxGreen);
            maxRed = Math.Max(red, maxRed);
        }

        return valid;
    }
}