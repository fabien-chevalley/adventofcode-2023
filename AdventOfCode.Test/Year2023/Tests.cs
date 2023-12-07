using AdventOfCode.Year2023;
using FluentAssertions;

namespace AdventOfCode.Test.Year2023;

public class Tests : BaseTests
{
    [Fact]
    public void Day1()
    {
        SolvePartOne<Day1, int>(GetInput<Day1>())
            .Should()
            .Be(54239);

        SolvePartTwo<Day1, int>(GetInput<Day1>())
            .Should()
            .Be(55343);
    }

    [Fact]
    public void Day2()
    {
        SolvePartOne<Day2, int>(GetInput<Day2>())
            .Should()
            .Be(3059);

        SolvePartTwo<Day2, int>(GetInput<Day2>())
            .Should()
            .Be(65371);
    }

    [Fact]
    public void Day3()
    {
        SolvePartOne<Day3, long>(GetInput<Day3>())
            .Should()
            .Be(514969);

        SolvePartTwo<Day3, long>(GetInput<Day3>())
            .Should()
            .Be(78915902);
    }

    [Fact]
    public void Day4()
    {
        SolvePartOne<Day4, long>(GetInput<Day4>())
            .Should()
            .Be(32609);

        SolvePartTwo<Day4, long>(GetInput<Day4>())
            .Should()
            .Be(14624680);
    }

    [Fact]
    public void Day5()
    {
        SolvePartOne<Day5, long>(GetInput<Day5>())
            .Should()
            .Be(165788812);

        SolvePartTwo<Day5, long>(GetInput<Day5>())
            .Should()
            .Be(1928058);
    }

    [Fact]
    public void Day6()
    {
        SolvePartOne<Day6, long>(GetInput<Day6>())
            .Should()
            .Be(1710720);

        SolvePartTwo<Day6, long>(GetInput<Day6>())
            .Should()
            .Be(35349468);
    }

    [Fact]
    public void Day7()
    {
        SolvePartOne<Day7, long>(GetInput<Day7>())
            .Should()
            .Be(251106089);

        SolvePartTwo<Day7, long>(GetInput<Day7>())
            .Should()
            .Be(249620106);
    }
}