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

        var next = new List<int>();
        for (var i = 1; i < numbers.Length; i++) next.Add(numbers[i] - numbers[i - 1]);

        return numbers.Last() + Reduce(next.ToArray());
    }
}