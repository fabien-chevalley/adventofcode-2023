using System.Reflection;

namespace AdventOfCode.Cli;

public static class Helper
{
    public static string GetInput()
    {
        var assembly = Assembly.GetExecutingAssembly();

        var resourceName = $"{typeof(Helper).Namespace}.input.txt";
        using var stream = assembly.GetManifestResourceStream(resourceName) ??
                           throw new ArgumentOutOfRangeException(nameof(resourceName),
                               $"Can not find embedded resource named {resourceName}");

        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}