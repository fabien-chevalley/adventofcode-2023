using System.Text.RegularExpressions;

namespace AdventOfCode.Year2023;

public class Day3 : ISolver<long>
{
    public long PartOne(string input)
    {
        var lines = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        var numbersByLine = lines
            .Select(line => Regex.Matches(line, @"(\d+)")
                .Where(m => m.Success)
                .SelectMany(m => m.Captures)
                .Select(c => new Result(c.Index, c.Value))
                .ToArray())
            .ToList();

        var specialCharsByLine = lines
            .Select(line => Regex.Matches(line, @"([^0-9\.\s])")
                .Where(m => m.Success)
                .SelectMany(m => m.Captures)
                .Select(c => new Result(c.Index, c.Value))
                .ToArray())
            .ToList();

        var results = new List<long>();
        for (var i = 0; i < lines.Length; i++)
            foreach (var number in numbersByLine[i])
            {
                var found = false;
                var specialChars = specialCharsByLine[i];
                foreach (var specialChar in specialChars)
                    if (specialChar.Index == number.Index + number.Text.Length ||
                        specialChar.Index == number.Index - 1)
                    {
                        results.Add(int.Parse(number.Text));
                        found = true;
                        break;
                    }

                if (!found && i > 0)
                {
                    specialChars = specialCharsByLine[i - 1];
                    foreach (var specialChar in specialChars)
                        if (specialChar.Index >= number.Index - 1 &&
                            specialChar.Index <= number.Index + number.Text.Length)
                        {
                            results.Add(int.Parse(number.Text));
                            found = true;
                            break;
                        }
                }

                if (!found && specialCharsByLine.Count > i + 1)
                {
                    specialChars = specialCharsByLine[i + 1];
                    foreach (var specialChar in specialChars)
                        if (specialChar.Index >= number.Index - 1 &&
                            specialChar.Index <= number.Index + number.Text.Length)
                        {
                            results.Add(int.Parse(number.Text));
                            found = true;
                            break;
                        }
                }

                if (!found) Console.WriteLine($"not found {number.Text} L{i}:{number.Index}");
            }

        return results.Sum();
    }

    public long PartTwo(string input)
    {
        var lines = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        var numbersByLine = lines
            .Select(line => Regex.Matches(line, @"(\d+)")
                .Where(m => m.Success)
                .SelectMany(m => m.Captures)
                .Select(c => new Result(c.Index, c.Value))
                .ToArray())
            .ToList();

        var specialCharsByLine = lines
            .Select(line => Regex.Matches(line, @"([^0-9\.\s])")
                .Where(m => m.Success)
                .SelectMany(m => m.Captures)
                .Select(c => new Result(c.Index, c.Value))
                .ToArray())
            .ToList();

        var results = new List<long>();
        for (var i = 0; i < lines.Length; i++)
            foreach (var specialChar in specialCharsByLine[i])
            {
                var gears = new List<long>();
                if (specialChar.Text == "*")
                {
                    var found = false;
                    var numbers = numbersByLine[i];
                    foreach (var number in numbers)
                        if (specialChar.Index == number.Index + number.Text.Length ||
                            specialChar.Index == number.Index - 1)
                            gears.Add(int.Parse(number.Text));

                    if (!found && i > 0)
                    {
                        numbers = numbersByLine[i - 1];
                        foreach (var number in numbers)
                            if (specialChar.Index >= number.Index - 1 &&
                                specialChar.Index <= number.Index + number.Text.Length)
                                gears.Add(int.Parse(number.Text));
                    }

                    if (!found && specialCharsByLine.Count > i + 1)
                    {
                        numbers = numbersByLine[i + 1];
                        foreach (var number in numbers)
                            if (specialChar.Index >= number.Index - 1 &&
                                specialChar.Index <= number.Index + number.Text.Length)
                                gears.Add(int.Parse(number.Text));
                    }
                }

                if (gears.Count == 2) results.Add(gears[0] * gears[1]);
            }

        return results.Sum();
    }

    private record Result(int Index, string Text)
    {
        public int Value => int.Parse(Text);
    }
}