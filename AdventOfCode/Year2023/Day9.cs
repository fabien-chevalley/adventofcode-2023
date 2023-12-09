namespace AdventOfCode.Year2023;

public class Day9 : ISolver<long>
{
    public long PartOne(string input)
    {
        var lines = input
            .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(l =>
                l.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

        return lines.Select(l => Reduce(l.ToArray())).Sum();
    }

    public long PartTwo(string input)
    {
        var lines = input
            .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(l =>
                l.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

        return lines.Select(l => Reduce(l.Reverse().ToArray())).Sum();
    }

    private static int Reduce(int[] numbers)
    {
        if (numbers.All(s => s == 0)) return 0;

        var next = new int[numbers.Length - 1];
        for (var i = 0; i < numbers.Length - 1; i++) next[i] = numbers[i + 1] - numbers[i];

        return numbers[^1] + Reduce(next);
    }
}