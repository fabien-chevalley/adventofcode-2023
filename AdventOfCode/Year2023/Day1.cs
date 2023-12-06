namespace AdventOfCode.Year2023;

public class Day1 : ISolver<int>
{
    private readonly string[] _digits =
        { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    private readonly string[] _digitsLiterals =
        { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

    public int PartOne(string input)
    {
        var sum = 0;
        var reader = new StringReader(input);
        var line = reader.ReadLine();
        while (line != null)
        {
            var first = _digits
                .Where(x => line.IndexOf(x) != -1)
                .Select(x => new { index = line.IndexOf(x), number = x })
                .OrderBy(x => x.index)
                .First();

            var last = _digits
                .Where(x => line.LastIndexOf(x) != -1)
                .Select(x => new { index = line.LastIndexOf(x), number = x })
                .OrderBy(x => x.index)
                .Last();

            sum += int.Parse($"{first.number}{last.number}");

            line = reader.ReadLine();
        }

        return sum;
    }

    public int PartTwo(string input)
    {
        var sum = 0;
        var reader = new StringReader(input);
        var line = reader.ReadLine();
        while (line != null)
        {
            var first = _digits
                .Concat(_digitsLiterals)
                .Where(x => line.IndexOf(x) != -1)
                .Select(x => new { index = line.IndexOf(x), number = Sanitize(x) })
                .OrderBy(x => x.index)
                .First();

            var last = _digits
                .Concat(_digitsLiterals)
                .Where(x => line.LastIndexOf(x) != -1)
                .Select(x => new { index = line.LastIndexOf(x), number = Sanitize(x) })
                .OrderBy(x => x.index)
                .Last();

            sum += int.Parse($"{first.number}{last.number}");

            line = reader.ReadLine();
        }

        return sum;
    }

    private string Sanitize(string number) =>
        number switch
        {
            "one" => "1",
            "two" => "2",
            "three" => "3",
            "four" => "4",
            "five" => "5",
            "six" => "6",
            "seven" => "7",
            "eight" => "8",
            "nine" => "9",
            _ => number
        };
}