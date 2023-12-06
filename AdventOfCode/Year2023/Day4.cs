namespace AdventOfCode.Year2023;

public class Day4 : ISolver<long>
{
    private readonly List<Card> _cards = new();

    public long PartOne(string input)
    {
        var lines = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        var index = 0;
        foreach (var line in lines) UpdateCards(line, index++);

        return (long)_cards.Select(x => x.Value).Sum();
    }

    public long PartTwo(string input)
    {
        var lines = input.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        var index = 0;
        foreach (var line in lines) UpdateCards(line, index++);

        return _cards.Where(c => c.Index < index).Select(x => x.Count).Sum();
    }

    private void UpdateCards(string line, int index)
    {
        var wins = line.Split(':')[1].Split('|')[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);

        var mines = line.Split(':')[1].Split('|')[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse);

        var matches = mines.Count(m => wins.Contains(m));

        var value = 0.0;

        if (matches == 1) value = 1;
        if (matches > 1) value = Math.Pow(2, matches - 1);

        var card = _cards.FirstOrDefault(x => x.Index == index);
        if (card != null)
        {
            card.Value = value;
            card.Count++;
        }
        else
        {
            card = new Card(index, 1, value);
            _cards.Add(card);
        }

        for (var i = 0; i < matches; i++)
        {
            var nextCard = _cards.FirstOrDefault(x => x.Index == index + i + 1);
            if (nextCard != null)
                nextCard.Count += card.Count;
            else
                _cards.Add(new Card(index + i + 1, card.Count, 0));
        }
    }

    private class Card(int index, int count, double value)
    {
        public int Index { get; } = index;

        public int Count { get; set; } = count;

        public double Value { get; set; } = value;
    }
}