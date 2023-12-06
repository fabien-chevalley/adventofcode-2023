namespace AdventOfCode;

public interface ISolver
{
}

public interface ISolver<out TResult> : ISolver
    where TResult : struct
{
    TResult PartOne(string input);
    TResult PartTwo(string input);
}