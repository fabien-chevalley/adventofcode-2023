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
        var accumulator = numbers.Last();
        var steps = new List<int>(numbers);
        var nextSteps = new List<int>();

        while (steps.Any(s => s != 0))
        {
            for (var i = 1; i < steps.Count; i++) nextSteps.Add(steps[i] - steps[i - 1]);

            accumulator += nextSteps.Last();

            if (steps.Any(s => s != 0))
            {
                steps = new List<int>(nextSteps);
                nextSteps = new List<int>();
            }
        }

        return accumulator;
    }
}