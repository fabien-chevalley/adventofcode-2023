using System.Reflection;

namespace AdventOfCode.Test;

public abstract class BaseTests
{
    protected string GetInput<TSolver>()
        where TSolver : ISolver
    {
        return GetInput($"Inputs.{typeof(TSolver).Name}.txt");
    }

    protected string GetInput(string input)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var resourceName = $"{GetType().Namespace}.{input}";
        using var stream = assembly.GetManifestResourceStream(resourceName) ??
                           throw new ArgumentOutOfRangeException(nameof(resourceName),
                               $"Can not find embedded resource named {resourceName}");

        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    protected TResult SolvePartOne<TSolver, TResult>(string input)
        where TSolver : ISolver<TResult>, new()
        where TResult : struct
    {
        var solver = new TSolver();
        return solver.PartOne(input);
    }

    protected TResult SolvePartTwo<TSolver, TResult>(string input)
        where TSolver : ISolver<TResult>, new()
        where TResult : struct
    {
        var solver = new TSolver();
        return solver.PartTwo(input);
    }
}