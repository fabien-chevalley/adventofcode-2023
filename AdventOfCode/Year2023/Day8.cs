using System.Text.RegularExpressions;
using MathNet.Numerics;

namespace AdventOfCode.Year2023;

public class Day8 : ISolver<long>
{
    public enum Instructions
    {
        Left,
        Right
    }

    private Instructions[] _instructions = { };
    private Node[] _networks = { };

    public long PartOne(string input)
    {
        var lines = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        _instructions = lines[0]
            .Trim()
            .Select(c => c == 'R' ? Instructions.Right : Instructions.Left)
            .ToArray();

        _networks = Regex
            .Matches(input, @"(\w{3}) = \((\w{3}), (\w{3})\)")
            .Select(m => new Node(m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value))
            .ToArray();

        return GoToEnd(_networks.First(n => n.Key == "AAA"), "ZZZ");
    }

    public long PartTwo(string input)
    {
        var lines = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        _instructions = lines[0]
            .Trim()
            .Select(c => c == 'R' ? Instructions.Right : Instructions.Left)
            .ToArray();

        _networks = Regex
            .Matches(input, @"(\w{3}) = \((\w{3}), (\w{3})\)")
            .Select(m => new Node(m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value))
            .ToArray();

        var nodes = _networks
            .Where(n => n.Key.EndsWith("A"))
            .ToArray();

        var paths = nodes
            .Select(node => GoToEnd(node, "Z"))
            .ToArray();

        return Euclid.LeastCommonMultiple(paths);
    }

    private long GoToEnd(Node start, string pattern)
    {
        long count = 0;
        var nextNode = start;
        while (!nextNode.Key.EndsWith(pattern))
        {
            nextNode = _networks.First(n =>
                n.Key == nextNode[_instructions[count % _instructions.Length]]);
            count++;
        }

        return count;
    }

    public class Node(string key, string left, string right)
    {
        public string Key => key;

        public string this[Instructions instruction]
        {
            get
            {
                return instruction switch
                {
                    Instructions.Left => left,
                    Instructions.Right => right,
                    _ => throw new ArgumentOutOfRangeException(nameof(instruction), instruction, null)
                };
            }
        }
    }
}