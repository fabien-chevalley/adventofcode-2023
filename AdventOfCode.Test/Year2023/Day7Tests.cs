using AdventOfCode.Year2023;
using FluentAssertions;

namespace AdventOfCode.Test.Year2023;

public class Day7Tests
{
    [Fact]
    public void Day7__Game__IsFiveOfKind()
    {
        var game = new Day7.Game("QQQQQ", string.Empty);
        game.IsFiveOfKind.Value.Should().BeTrue();
        game.IsThreeOfKind.Value.Should().BeFalse();
        game.IsFourOfKind.Value.Should().BeFalse();
        game.IsFull.Value.Should().BeFalse();
        game.IsTwoPairs.Value.Should().BeFalse();
        game.IsPair.Value.Should().BeFalse();
    }

    [Fact]
    public void Day7__Game__IsFourOfKind()
    {
        var game = new Day7.Game("AQQQQ", string.Empty);
        game.IsFourOfKind.Value.Should().BeTrue();
        game.IsFiveOfKind.Value.Should().BeFalse();
        game.IsThreeOfKind.Value.Should().BeFalse();
        game.IsFull.Value.Should().BeFalse();
        game.IsTwoPairs.Value.Should().BeFalse();
        game.IsPair.Value.Should().BeFalse();
    }

    [Fact]
    public void Day7__Game__IsFull()
    {
        var game = new Day7.Game("AAQQQ", string.Empty);
        game.IsFull.Value.Should().BeTrue();
        game.IsFiveOfKind.Value.Should().BeFalse();
        game.IsFourOfKind.Value.Should().BeFalse();
        game.IsThreeOfKind.Value.Should().BeFalse();
        game.IsTwoPairs.Value.Should().BeFalse();
        game.IsPair.Value.Should().BeFalse();
    }

    [Fact]
    public void Day7__Game__IsThreeOfKind()
    {
        var game = new Day7.Game("ATQQQ", string.Empty);
        game.IsThreeOfKind.Value.Should().BeTrue();
        game.IsFull.Value.Should().BeFalse();
        game.IsFiveOfKind.Value.Should().BeFalse();
        game.IsFourOfKind.Value.Should().BeFalse();
        game.IsTwoPairs.Value.Should().BeFalse();
        game.IsPair.Value.Should().BeFalse();
    }

    [Fact]
    public void Day7__Game__IsTwoPairs()
    {
        var game = new Day7.Game("AATQQ", string.Empty);
        game.IsTwoPairs.Value.Should().BeTrue();
        game.IsFull.Value.Should().BeFalse();
        game.IsFiveOfKind.Value.Should().BeFalse();
        game.IsFourOfKind.Value.Should().BeFalse();
        game.IsThreeOfKind.Value.Should().BeFalse();
        game.IsPair.Value.Should().BeFalse();
    }

    [Fact]
    public void Day7__Game__IsPair()
    {
        var game = new Day7.Game("AATJ5", string.Empty);
        game.IsPair.Value.Should().BeTrue();
        game.IsFull.Value.Should().BeFalse();
        game.IsFiveOfKind.Value.Should().BeFalse();
        game.IsFourOfKind.Value.Should().BeFalse();
        game.IsThreeOfKind.Value.Should().BeFalse();
        game.IsTwoPairs.Value.Should().BeFalse();
    }

    [Fact]
    public void Day7__Game__Sort()
    {
        var game1 = new Day7.Game("AATJ5", string.Empty);
        var game2 = new Day7.Game("TJ5AA", string.Empty);

        var games = new List<Day7.Game> { game2, game1 };
        games.Sort();

        games.First().Should().Be(game1);
    }
}